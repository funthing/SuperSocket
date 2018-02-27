namespace SuperSocket
{
    partial class frmSocketManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnOpenSocket = new System.Windows.Forms.Button();
            this.btnCloseSocket = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.dgvSesssions = new System.Windows.Forms.DataGridView();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSessionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmOperational = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmIsLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSesssions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenSocket
            // 
            this.btnOpenSocket.Location = new System.Drawing.Point(64, 26);
            this.btnOpenSocket.Name = "btnOpenSocket";
            this.btnOpenSocket.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSocket.TabIndex = 0;
            this.btnOpenSocket.Text = "打开服务器";
            this.btnOpenSocket.UseVisualStyleBackColor = true;
            this.btnOpenSocket.Click += new System.EventHandler(this.btnOpenSocket_Click);
            // 
            // btnCloseSocket
            // 
            this.btnCloseSocket.Location = new System.Drawing.Point(212, 26);
            this.btnCloseSocket.Name = "btnCloseSocket";
            this.btnCloseSocket.Size = new System.Drawing.Size(75, 23);
            this.btnCloseSocket.TabIndex = 1;
            this.btnCloseSocket.Text = "关闭服务器";
            this.btnCloseSocket.UseVisualStyleBackColor = true;
            this.btnCloseSocket.Click += new System.EventHandler(this.btnCloseSocket_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(335, 28);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(319, 104);
            this.txtMessage.TabIndex = 2;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(704, 109);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "发送消息";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(12, 55);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(308, 508);
            this.txtLog.TabIndex = 4;
            // 
            // dgvSesssions
            // 
            this.dgvSesssions.AllowUserToAddRows = false;
            this.dgvSesssions.AllowUserToDeleteRows = false;
            this.dgvSesssions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSesssions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmName,
            this.clmSessionID,
            this.clmIP,
            this.clmSelect,
            this.clmOperational,
            this.clmIsLogin});
            this.dgvSesssions.Location = new System.Drawing.Point(335, 152);
            this.dgvSesssions.Name = "dgvSesssions";
            this.dgvSesssions.ReadOnly = true;
            this.dgvSesssions.RowTemplate.Height = 23;
            this.dgvSesssions.Size = new System.Drawing.Size(719, 401);
            this.dgvSesssions.TabIndex = 6;
            this.dgvSesssions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSesssions_CellContentClick);
            this.dgvSesssions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSesssions_CellFormatting);
            this.dgvSesssions.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSesssions_DataError);
            // 
            // clmName
            // 
            this.clmName.DataPropertyName = "SN";
            this.clmName.HeaderText = "名称";
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            // 
            // clmSessionID
            // 
            this.clmSessionID.DataPropertyName = "SessionID";
            this.clmSessionID.HeaderText = "SessionID";
            this.clmSessionID.Name = "clmSessionID";
            this.clmSessionID.ReadOnly = true;
            this.clmSessionID.Visible = false;
            // 
            // clmIP
            // 
            this.clmIP.DataPropertyName = "IP";
            this.clmIP.HeaderText = "IP地址";
            this.clmIP.Name = "clmIP";
            this.clmIP.ReadOnly = true;
            // 
            // clmSelect
            // 
            this.clmSelect.HeaderText = "选择";
            this.clmSelect.Name = "clmSelect";
            this.clmSelect.ReadOnly = true;
            // 
            // clmOperational
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "关闭";
            this.clmOperational.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmOperational.HeaderText = "操作";
            this.clmOperational.Name = "clmOperational";
            this.clmOperational.ReadOnly = true;
            this.clmOperational.Text = "关闭";
            this.clmOperational.ToolTipText = "关闭这个客户端";
            // 
            // clmIsLogin
            // 
            this.clmIsLogin.DataPropertyName = "IsLogin";
            this.clmIsLogin.HeaderText = "是否登陆";
            this.clmIsLogin.Name = "clmIsLogin";
            this.clmIsLogin.ReadOnly = true;
            // 
            // frmSocketManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 565);
            this.Controls.Add(this.dgvSesssions);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnCloseSocket);
            this.Controls.Add(this.btnOpenSocket);
            this.Name = "frmSocketManager";
            this.Text = "socketManager";
            this.Load += new System.EventHandler(this.socketManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSesssions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenSocket;
        private System.Windows.Forms.Button btnCloseSocket;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendMessage;
        public System.Windows.Forms.TextBox txtLog;
        public System.Windows.Forms.DataGridView dgvSesssions;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSessionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSelect;
        private System.Windows.Forms.DataGridViewButtonColumn clmOperational;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIsLogin;
    }
}