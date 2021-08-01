namespace fourG.Sms
{
    partial class frmSMSCInterface
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lvLOG = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSendTime = new System.Windows.Forms.Label();
            this.btnStopSend = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStartSend = new System.Windows.Forms.Button();
            this.chShowlogs = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lvLOG, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.22865F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.77135F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1721, 726);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lvLOG
            // 
            this.lvLOG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLOG.HideSelection = false;
            this.lvLOG.Location = new System.Drawing.Point(3, 70);
            this.lvLOG.Name = "lvLOG";
            this.lvLOG.Size = new System.Drawing.Size(1715, 653);
            this.lvLOG.TabIndex = 0;
            this.lvLOG.UseCompatibleStateImageBehavior = false;
            this.lvLOG.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblSendTime);
            this.groupBox1.Controls.Add(this.btnStopSend);
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnStartSend);
            this.groupBox1.Controls.Add(this.chShowlogs);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1715, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblSendTime
            // 
            this.lblSendTime.AutoSize = true;
            this.lblSendTime.Location = new System.Drawing.Point(1343, 26);
            this.lblSendTime.Name = "lblSendTime";
            this.lblSendTime.Size = new System.Drawing.Size(17, 20);
            this.lblSendTime.TabIndex = 6;
            this.lblSendTime.Text = "0";
            // 
            // btnStopSend
            // 
            this.btnStopSend.Location = new System.Drawing.Point(753, 19);
            this.btnStopSend.Name = "btnStopSend";
            this.btnStopSend.Size = new System.Drawing.Size(94, 29);
            this.btnStopSend.TabIndex = 1;
            this.btnStopSend.Text = "Stop Send";
            this.btnStopSend.UseVisualStyleBackColor = true;
            this.btnStopSend.Click += new System.EventHandler(this.btnStopSend_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(18, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(88, 45);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Title";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(853, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 29);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStartSend
            // 
            this.btnStartSend.Location = new System.Drawing.Point(653, 19);
            this.btnStartSend.Name = "btnStartSend";
            this.btnStartSend.Size = new System.Drawing.Size(94, 29);
            this.btnStartSend.TabIndex = 1;
            this.btnStartSend.Text = "Start Send";
            this.btnStartSend.UseVisualStyleBackColor = true;
            this.btnStartSend.Click += new System.EventHandler(this.btnStartSend_Click);
            // 
            // chShowlogs
            // 
            this.chShowlogs.AutoSize = true;
            this.chShowlogs.Checked = true;
            this.chShowlogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chShowlogs.Location = new System.Drawing.Point(969, 22);
            this.chShowlogs.Name = "chShowlogs";
            this.chShowlogs.Size = new System.Drawing.Size(99, 24);
            this.chShowlogs.TabIndex = 3;
            this.chShowlogs.Text = "Show logs";
            this.chShowlogs.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(553, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 1;
            this.button3.Text = "Connect";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmSMSCInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1721, 726);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSMSCInterface";
            this.Text = "frmSMSCInterface";
            this.Load += new System.EventHandler(this.frmSMSCInterface_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lvLOG;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStartSend;
        private System.Windows.Forms.CheckBox chShowlogs;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnStopSend;
        private System.Windows.Forms.Label lblSendTime;
    }
}