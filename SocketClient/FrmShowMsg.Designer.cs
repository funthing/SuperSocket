namespace SocketClient
{
    partial class FrmShowMsg
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
            this.txtReciveMsg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblAutoReconnention = new System.Windows.Forms.Label();
            this.linklblConnention = new System.Windows.Forms.LinkLabel();
            this.lblSendMsg = new System.Windows.Forms.Label();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtReciveMsg
            // 
            this.txtReciveMsg.Location = new System.Drawing.Point(4, 12);
            this.txtReciveMsg.Multiline = true;
            this.txtReciveMsg.Name = "txtReciveMsg";
            this.txtReciveMsg.Size = new System.Drawing.Size(557, 514);
            this.txtReciveMsg.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(722, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(28, 12);
            this.panel1.TabIndex = 3;
            // 
            // cmbAction
            // 
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(617, 424);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(121, 20);
            this.cmbAction.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(663, 477);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(580, 199);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(158, 204);
            this.txtSendMessage.TabIndex = 6;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.Location = new System.Drawing.Point(577, 22);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(40, 16);
            this.lblState.TabIndex = 7;
            this.lblState.Text = "在线";
            // 
            // lblAutoReconnention
            // 
            this.lblAutoReconnention.AutoSize = true;
            this.lblAutoReconnention.Location = new System.Drawing.Point(567, 63);
            this.lblAutoReconnention.Name = "lblAutoReconnention";
            this.lblAutoReconnention.Size = new System.Drawing.Size(185, 12);
            this.lblAutoReconnention.TabIndex = 8;
            this.lblAutoReconnention.Text = "连接服务器失败，60秒后自动重连";
            this.lblAutoReconnention.Visible = false;
            // 
            // linklblConnention
            // 
            this.linklblConnention.AutoSize = true;
            this.linklblConnention.Location = new System.Drawing.Point(685, 86);
            this.linklblConnention.Name = "linklblConnention";
            this.linklblConnention.Size = new System.Drawing.Size(53, 12);
            this.linklblConnention.TabIndex = 9;
            this.linklblConnention.TabStop = true;
            this.linklblConnention.Text = "立即重连";
            this.linklblConnention.Visible = false;
            this.linklblConnention.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblConnention_LinkClicked);
            // 
            // lblSendMsg
            // 
            this.lblSendMsg.AutoSize = true;
            this.lblSendMsg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSendMsg.Location = new System.Drawing.Point(578, 167);
            this.lblSendMsg.Name = "lblSendMsg";
            this.lblSendMsg.Size = new System.Drawing.Size(147, 14);
            this.lblSendMsg.TabIndex = 10;
            this.lblSendMsg.Text = "向服务器端发送消息：";
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // FrmShowMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 529);
            this.Controls.Add(this.lblSendMsg);
            this.Controls.Add(this.linklblConnention);
            this.Controls.Add(this.lblAutoReconnention);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtReciveMsg);
            this.Name = "FrmShowMsg";
            this.Text = "FrmShowMsg";
            this.Load += new System.EventHandler(this.FrmShowMsg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.Label lblSendMsg;
        public System.Windows.Forms.TextBox txtReciveMsg;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblState;
        public System.Windows.Forms.Label lblAutoReconnention;
        public System.Windows.Forms.LinkLabel linklblConnention;
        public System.ComponentModel.BackgroundWorker worker;
    }
}