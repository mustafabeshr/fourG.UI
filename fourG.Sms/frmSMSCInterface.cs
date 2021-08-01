using ArdanStudios.Common.SmppClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fourG.Sms
{
    public partial class frmSMSCInterface : Form
    {
        private readonly IConfiguration _configuration;
        private readonly string _interfaceType;
        private readonly SMSCReceiverSettings receiverSettings;
        private readonly SMSCSenderSettings senderSettings;
        private string SMSCShortcode;
        private string SMSCServer;
        private int SMSCPort;
        private string SMSCSystemId;
        private string SMSCPassword;
        private int SMSCInterfaceCount;
        private static Timer timer1;
        private bool isReadyToLoadMessagesFromDb = true;

        ESMEManager connectionManager;
        public frmSMSCInterface(IConfiguration configuration, string title, string interfaceType)
        {
            InitializeComponent();
            _configuration = configuration;
            this._interfaceType = interfaceType;
            receiverSettings = new SMSCReceiverSettings();
            senderSettings = new SMSCSenderSettings();
            configuration.GetSection("SmscSettings:Receiver").Bind(receiverSettings);
            configuration.GetSection("SmscSettings:Sender").Bind(senderSettings);
            lblTitle.Text = title;
            if (interfaceType == "R")
            {
                SMSCServer = receiverSettings.Server;
                SMSCPort = int.Parse(receiverSettings.Port);
                SMSCSystemId = receiverSettings.SystemId;
                SMSCPassword = receiverSettings.Password;
                SMSCInterfaceCount = int.Parse(receiverSettings.Count);
                SMSCShortcode = receiverSettings.Shortcode;
                btnStartSend.Visible = false;
            }
            if (interfaceType == "S")
            {
                SMSCServer = senderSettings.Server;
                SMSCPort = int.Parse(senderSettings.Port);
                SMSCSystemId = senderSettings.SystemId;
                SMSCPassword = senderSettings.Password;
                SMSCInterfaceCount = int.Parse(senderSettings.Count);
                SMSCShortcode = senderSettings.Shortcode;
                btnStartSend.Visible = true;
            }

            lvLOG
                .GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(lvLOG, true, null);
        }

        private void PrepareLogListView()
        {
            lvLOG.View = View.Details;
            lvLOG.GridLines = true;
            lvLOG.FullRowSelect = true;

            //Add column header
            lvLOG.Columns.Add("Mobile", 200, HorizontalAlignment.Center);
            lvLOG.Columns.Add("Message", 800, HorizontalAlignment.Left);
            lvLOG.Columns.Add("Type", 50, HorizontalAlignment.Center);
            lvLOG.Columns.Add("Short Code", 150, HorizontalAlignment.Center);
            lvLOG.Columns.Add("Time", 240, HorizontalAlignment.Center);
            lvLOG.Columns.Add("Event", 140, HorizontalAlignment.Left);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connectionManager = new ESMEManager("SMS", SMSCShortcode, new ESMEManager.CONNECTION_EVENT_HANDLER(connectionEventHandler),
                new ESMEManager.RECEIVED_MESSAGE_HANDLER(receivedMessageHandler), new ESMEManager.RECEIVED_GENERICNACK_HANDLER(receivedGenricnackHandler),
                new ESMEManager.SUBMIT_MESSAGE_HANDLER(submitMessageHandler), new ESMEManager.QUERY_MESSAGE_HANDLER(queryMessageHandler),
                new ESMEManager.LOG_EVENT_HANDLER(logEventHandler), new ESMEManager.PDU_DETAILS_EVENT_HANDLER(pduDetailsEventHandler));


            connectionManager.AddConnections(SMSCInterfaceCount, _interfaceType == "R" ? ConnectionModes.Receiver : ConnectionModes.Transmitter, 
                SMSCServer, SMSCPort, SMSCSystemId, SMSCPassword, "R", DataCodings.Default);
        }

        private void submitMessageHandler(string logKey, int sequence, string messageId)
        {
            if (chShowlogs.Checked)
            {
                AddLog(logKey, "sequence=" + sequence.ToString() + "|messageId=" + messageId, "SMT", SMSCShortcode, "SubmitMessageHandler", Color.Gray);
            }
        }

        private void logEventHandler(LogEventNotificationTypes logEventNotificationType, string logKey, string shortLongCode, string message)
        {
            if (chShowlogs.Checked)
            {
                AddLog(logKey, "log Type=" + logEventNotificationType.ToString() + "|message=" + message
                , "LOG", shortLongCode, "LogEventHandler", Color.Gray);
            }
        }

        private Guid? pduDetailsEventHandler(string logKey, PduDirectionTypes pduDirectionType, Header pdu, List<PduPropertyDetail> details)
        {
            throw new NotImplementedException();
        }

        private void queryMessageHandler(string logKey, int sequence, string messageId, DateTime finalDate, int messageState, long errorCode)
        {
            if (chShowlogs.Checked)
            {
                AddLog(logKey, "sequence=" + sequence.ToString() + "|messageId=" + messageId
               + "|finalDate=" + finalDate.ToString("yyyyMMddHmmss") + "|messageState=" + messageState.ToString()
                + "|errorCode=" + errorCode.ToString()
                , "QRY", SMSCShortcode, "QueryMessageHandler", Color.Gray);

            }
        }

        private void receivedGenricnackHandler(string logKey, int sequence)
        {
            if (chShowlogs.Checked)
            {
                AddLog(logKey, "sequence=" + sequence.ToString(), "NCK", SMSCShortcode, "ReceivedGenericNackHandler", Color.Gray);
            }
        }

        private void receivedMessageHandler(string logKey, string serviceType, Ton sourceTon, Npi sourceNpi, string shortLongCode, DateTime dateReceived, string phoneNumber, DataCodings dataCoding, string message)
        {
            AddLogAsync(phoneNumber, message, "IN", shortLongCode, "ReceivedMessageHandler", Color.Blue);
            if (!string.IsNullOrEmpty(message))
            {
               
            }
        }

        private void connectionEventHandler(string logKey, ConnectionEventTypes connectionEventType, string message)
        {
            if (chShowlogs.Checked)
            {
                AddLog(logKey, connectionEventType.ToString() + "  " + message, "CON", SMSCShortcode, "ConnectionEvent", Color.Gray);
            }
        }

        private void frmSMSCInterface_Load(object sender, EventArgs e)
        {
            PrepareLogListView();
        }

        private void AddLog(string mobileno, string MessageValue, string TypeValue,
           string shortcode, string appEvent, Color forecolor)
        {

            //Add items in the listview
            string[] arr = new string[6];
            ListViewItem itm;

            //Add first item
            arr[0] = mobileno;
            arr[1] = MessageValue;
            arr[2] = TypeValue;
            arr[3] = shortcode;
            arr[4] = DateTime.Now.ToString("ss:mm:H dd/MM/yyyy");
            arr[5] = appEvent;
            itm = new ListViewItem(arr);
            itm.ForeColor = forecolor;
            itm.ImageIndex = 1;
            //lvLOG.Items.Add(itm);
            if (lvLOG.InvokeRequired)
                lvLOG.Invoke((MethodInvoker)delegate ()
                {
                    lvLOG.Items.Add(itm);
                    lvLOG.EnsureVisible(lvLOG.Items.Count - 1);
                    if (lvLOG.Items.Count > 90)
                    {
                        lvLOG.Items.Clear();
                    }
                });
        }

        private async Task AddLogAsync(string mobileno, string MessageValue, string TypeValue,
            string shortcode, string appEvent, Color forecolor)
        {

            //Add items in the listview
            string[] arr = new string[6];
            ListViewItem itm;

            //Add first item
            arr[0] = mobileno;
            arr[1] = MessageValue;
            arr[2] = TypeValue;
            arr[3] = shortcode;
            arr[4] = DateTime.Now.ToString("ss:mm:H dd/MM/yyyy");
            arr[5] = appEvent;
            itm = new ListViewItem(arr);
            itm.ForeColor = forecolor;
            itm.ImageIndex = 1;
            //lvLOG.Items.Add(itm);
            await Task.Run(() => {
                if (lvLOG.InvokeRequired)
                    lvLOG.Invoke((MethodInvoker)delegate ()
                    {
                        lvLOG.Items.Add(itm);
                        lvLOG.EnsureVisible(lvLOG.Items.Count - 1);
                        if (lvLOG.Items.Count > 90)
                        {
                            lvLOG.Items.Clear();
                        }
                    });
            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvLOG.Items.Clear();
        }

        private void btnStartSend_Click(object sender, EventArgs e)
        {
            AddLogAsync("SYS", "Start send", "", "", "", Color.Purple);
            timer1 = new Timer();
            timer1.Tick += (async (sender, e) =>
            {
                await Task.Run(() =>
                {
                    if (isReadyToLoadMessagesFromDb)
                    {
                        SendGeneratedMessages();
                    }
                });
            });

            timer1.Interval = 5000;
            timer1.Start();
        }

        private void SendGeneratedMessages()
        {
            int sendResult = 0;
            isReadyToLoadMessagesFromDb = false;
            AddLogAsync("SYS", "Try to load messages from database", "", "", "Load Messages", Color.Purple);
            var messages = new List<string>
            {
                "Hello","Hello Mustafa"
            };// get messages from database
            if (messages != null && messages.Count > 0)
            {
                AddLogAsync("SYS", $"Load {messages.Count} messages", "", "", "Load Messages", Color.Purple);
                foreach (var message in messages)
                {
                        if (lblSendTime.InvokeRequired)
                        {
                            Invoke((MethodInvoker)delegate ()
                            {
                                var cnt = int.Parse(lblSendTime.Text);
                                lblSendTime.Text = (++cnt).ToString();
                            });
                        }
                    SubmitSm submitSm = null;
                    SubmitSmResp submitSmResp = null;
                    List<SubmitSm> submitSmList = null;
                    List<SubmitSmResp> submitSmRespList = null;
                    if (message.Length <= 70)
                    {
                        sendResult = connectionManager.SendMessage("777010055", null, Ton.Unknown, Npi.Unknown, DataCodings.UCS2
                                       , DataCodings.UCS2, message, out submitSm, out submitSmResp);
                    }
                    else
                    {
                        sendResult = connectionManager.SendMessageLarge("777010055", null, Ton.Unknown, Npi.Unknown, DataCodings.UCS2
                                      , DataCodings.UCS2, message, out submitSmList, out submitSmRespList);
                    }
                    AddLog(message, message, "OUT", SMSCShortcode, (sendResult == 0 ? "Success" : "Fail"),
                        (sendResult == 0 ? Color.Black : Color.Red));
                    if (sendResult == 0)
                    {
                        // remove message from message pool 
                    }
                }
            } else
            {
                AddLogAsync("SYS", "No pending messages", "", "", "", Color.Purple);
            }
            isReadyToLoadMessagesFromDb = true;
        }

        private void btnStopSend_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            isReadyToLoadMessagesFromDb = true;
            AddLogAsync("SYS", "Stop sending", "", "", "", Color.Purple);
        }
    }
}
