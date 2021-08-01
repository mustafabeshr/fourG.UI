using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fourG.Sms
{
    public partial class frmSettings : Form
    {
        private readonly IConfiguration configuration;
        private readonly SMSCReceiverSettings receiverSettings;
        private readonly SMSCSenderSettings senderSettings;
        

        public frmSettings(IConfiguration configuration)
        {
            InitializeComponent();
            this.configuration = configuration;
            receiverSettings = new SMSCReceiverSettings();
            senderSettings = new SMSCSenderSettings();
            configuration.GetSection("SmscSettings:Receiver").Bind(receiverSettings);
            configuration.GetSection("SmscSettings:Sender").Bind(senderSettings);
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtRecServer.Text = receiverSettings.Server;
            txtRecPort.Text = receiverSettings.Port;
            txtRecSysId.Text = receiverSettings.SystemId;
            txtRecPassword.Text = receiverSettings.Password;
            txtRecCount.Text = receiverSettings.Count;
            txtRecShortcode.Text = receiverSettings.Shortcode;

            txtSenServer.Text = senderSettings.Server;
            txtSenPort.Text = senderSettings.Port;
            txtSenSysId.Text = senderSettings.SystemId;
            txtSenPassword.Text = senderSettings.Password;
            txtSenCount.Text = senderSettings.Count;
            txtSenShortcode.Text = senderSettings.Shortcode;
        }
    }
}
