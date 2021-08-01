namespace fourG.Sms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnReceiver = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSender = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTailH = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTailV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCloseAll = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.White;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReceiver,
            this.toolStripSeparator1,
            this.btnSender,
            this.toolStripSeparator2,
            this.btnSettings,
            this.toolStripSeparator3,
            this.btnTailH,
            this.toolStripSeparator4,
            this.btnTailV,
            this.toolStripSeparator5,
            this.btnCloseAll});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1620, 60);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // btnReceiver
            // 
            this.btnReceiver.ForeColor = System.Drawing.Color.Green;
            this.btnReceiver.Image = ((System.Drawing.Image)(resources.GetObject("btnReceiver.Image")));
            this.btnReceiver.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReceiver.Margin = new System.Windows.Forms.Padding(5);
            this.btnReceiver.Name = "btnReceiver";
            this.btnReceiver.Size = new System.Drawing.Size(69, 50);
            this.btnReceiver.Text = "Receiver";
            this.btnReceiver.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnReceiver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReceiver.ToolTipText = "Open Receiver";
            this.btnReceiver.Click += new System.EventHandler(this.ShowSMSCInterfaceForm);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 60);
            // 
            // btnSender
            // 
            this.btnSender.ForeColor = System.Drawing.Color.Blue;
            this.btnSender.Image = ((System.Drawing.Image)(resources.GetObject("btnSender.Image")));
            this.btnSender.ImageTransparentColor = System.Drawing.Color.Blue;
            this.btnSender.Margin = new System.Windows.Forms.Padding(5);
            this.btnSender.Name = "btnSender";
            this.btnSender.Size = new System.Drawing.Size(59, 50);
            this.btnSender.Text = "Sender";
            this.btnSender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSender.Click += new System.EventHandler(this.ShowSMSCInterfaceForm);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 60);
            // 
            // btnSettings
            // 
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Margin = new System.Windows.Forms.Padding(5);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(66, 50);
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSettings.Click += new System.EventHandler(this.ShowSettingsForm);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 60);
            // 
            // btnTailH
            // 
            this.btnTailH.Image = ((System.Drawing.Image)(resources.GetObject("btnTailH.Image")));
            this.btnTailH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTailH.Margin = new System.Windows.Forms.Padding(5);
            this.btnTailH.Name = "btnTailH";
            this.btnTailH.Size = new System.Drawing.Size(94, 50);
            this.btnTailH.Text = "Horizontally";
            this.btnTailH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTailH.ToolTipText = "Tail Horizontally";
            this.btnTailH.Click += new System.EventHandler(this.TailVertically);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 60);
            // 
            // btnTailV
            // 
            this.btnTailV.Image = ((System.Drawing.Image)(resources.GetObject("btnTailV.Image")));
            this.btnTailV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTailV.Margin = new System.Windows.Forms.Padding(5);
            this.btnTailV.Name = "btnTailV";
            this.btnTailV.Size = new System.Drawing.Size(73, 50);
            this.btnTailV.Text = "Vertically";
            this.btnTailV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTailV.ToolTipText = "Tail Vertically";
            this.btnTailV.Click += new System.EventHandler(this.TailHorizontally);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 60);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseAll.Image")));
            this.btnCloseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseAll.Margin = new System.Windows.Forms.Padding(5);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(69, 50);
            this.btnCloseAll.Text = "Close all";
            this.btnCloseAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCloseAll.Click += new System.EventHandler(this.CloseAllForms);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 671);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1620, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 697);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4G  - SMS - Module";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripButton btnReceiver;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSender;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnTailH;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnTailV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCloseAll;
    }
}



