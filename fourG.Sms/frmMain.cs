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
    public partial class frmMain : Form
    {
        private int childFormNumber = 0;
        private readonly IConfiguration configuration;

        public frmMain(IConfiguration configuration)
        {
            InitializeComponent();
            this.configuration = configuration;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void ShowSettingsForm(object sender, EventArgs e)
        {
            if (IsFormAlreadyLoaded("frmSettings") == true)
            {
                return;
            }

            frmSettings frm = new frmSettings(configuration);
            frm.MdiParent = this;
            frm.Text = "Settings";
            frm.Show();
        }

        private void ShowSMSCInterfaceForm(object sender, EventArgs e)
        {
            var frmTag = sender.ToString() == "Receiver" ? "frmSMSCInterfaceR" : "frmSMSCInterfaceS";

            if (IsFormAlreadyLoaded(frmTag) == true)
            {
                return;
            }

            frmSMSCInterface frm = new frmSMSCInterface(configuration, sender.ToString(), sender.ToString().Substring(0,1));
            frm.Tag = frmTag;
            frm.MdiParent = this;
            frm.Text = sender.ToString();
            frm.Show();
        }

        private void CloseAllForms(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void TailVertically(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void TailHorizontally(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private bool IsFormAlreadyLoaded(string formToLoadName)
        {
            foreach (Form frmChild in this.MdiChildren)
            {
                if (frmChild.Tag.ToString() == formToLoadName)
                { frmChild.Activate(); return true; }
            }
            return false;
        }

    }
}
