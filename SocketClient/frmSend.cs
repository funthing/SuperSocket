using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class frmSend : Form
    {
        public frmSend()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSend_Load(object sender, EventArgs e)
        {
            cmbAction.Items.Add(new { DisplayMember = "请选择消息类型", ValueMember = "" });
            cmbAction.Items.Add(new { DisplayMember = "心跳", ValueMember = "HERTBEAT" });
            cmbAction.Items.Add(new { DisplayMember = "登陆", ValueMember = "LOGIN" });
            cmbAction.SelectedIndex = 0;
            cmbAction.DisplayMember = "DisplayMember";
            cmbAction.ValueMember = "ValueMember";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            dynamic item =cmbAction.SelectedItem;
            if(item==null|| item.ValueMember == "")
            {
                cmbAction.DroppedDown = true;
                return;
            }
            dynamic body = new { SN = "测试账号" };
            string bodyStr = JsonConvert.SerializeObject(body);
            SocketClientHelper.Send(item.ValueMember, bodyStr);
        }
    }
}
