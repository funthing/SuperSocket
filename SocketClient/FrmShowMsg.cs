using Newtonsoft.Json;
using SocketClient.SocketClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class FrmShowMsg : Form
    {
        public FrmShowMsg()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            dynamic item = cmbAction.SelectedItem;
            if (item == null || item.ValueMember == "")
            {
                cmbAction.DroppedDown = true;
                return;
            }
            dynamic body = new { SN = "测试账号" };
            string bodyStr = JsonConvert.SerializeObject(body);
            SocketClientHelper.Send(item.ValueMember, bodyStr);
        }

        private void FrmShowMsg_Load(object sender, EventArgs e)
        {
            //将窗体当作变量赋值给类，以便于在类中操作窗体中的控件
            FormHelper.frm = this;
            cmbAction.Items.Add(new { DisplayMember = "请选择消息类型", ValueMember = "" });
            cmbAction.Items.Add(new { DisplayMember = "心跳", ValueMember = "HEARTBEAT" });
            cmbAction.Items.Add(new { DisplayMember = "登陆", ValueMember = "LOGIN" });
            cmbAction.SelectedIndex = 0;
            cmbAction.DisplayMember = "DisplayMember";
            cmbAction.ValueMember = "ValueMember";
            if (SocketClientHelper.ConnectionServer())
            {
                SocketClientHelper.ReceiveMsg += SocketCilentHelper_ReceiveMsg;
                FormHelper.IsConnect();
                dynamic body = new { SN = "测试账号" };
                string bodyStr = JsonConvert.SerializeObject(body);
                SocketClientHelper.Send("LOGIN", bodyStr);
                QuartzHelper.Start();
            }
            else
            {
                FormHelper.DisConnect();
                worker.RunWorkerAsync(60);
            }
        }

        private void SocketCilentHelper_ReceiveMsg(string msg)
        {
            this.Invoke(new Action(() =>
            {
                if (msg != "OK\r\n")
                {
                    txtReciveMsg.Text += $"收到服务器发来消息：{msg + Environment.NewLine}";
                }
            }));
        }

        private void linklblConnention_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SocketClientHelper.ConnectionServer())
            {
                FormHelper.IsConnect();
                worker.CancelAsync();
            }
            else
            {
                txtReciveMsg.Text += $"重连失败{Environment.NewLine}";
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            int endNum = 0;
            if (e.Argument != null)
            {
                endNum = int.Parse(e.Argument.ToString());
                for (int i = endNum; i > 0; i--)
                {
                    if (!worker.CancellationPending)
                    {
                        Thread.Sleep(1000);
                        worker.ReportProgress(i - 1);
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                if (!SocketClientHelper.ConnectionServer())
                {
                    worker.RunWorkerAsync(60);
                }
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //TODO:在此方法内操作窗体不应报错
            lblAutoReconnention.Text = $"您已掉线，将在{e.ProgressPercentage}秒后自动重连";
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //判断任务完成是正常完成还是被取消掉
            if(!e.Cancelled)
            {
                if (SocketClientHelper.ConnectionServer())
                {
                    FormHelper.IsConnect();
                }
                else
                {
                    txtReciveMsg.Text += $"重连失败{Environment.NewLine}";
                    worker.RunWorkerAsync(60);
                }
            }
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
