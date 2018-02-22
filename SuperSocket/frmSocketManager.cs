using SuperSocket.SocketBase;
using SuperSocket.SuperSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperSocket
{
    public partial class frmSocketManager : Form
    {
        private List<FunThingSession> sessions = new List<FunThingSession>();

        public frmSocketManager()
        {
            InitializeComponent();
        }

        private void btnOpenSocket_Click(object sender, EventArgs e)
        {
            SocketHelper.openSocket();
        }

        private void socketManager_Load(object sender, EventArgs e)
        {
            //将窗体当作变量赋值给类，以便于在类中操作窗体中的控件
            FormHelper.frm = this;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            //if(cmbSessions.SelectedItem.ToString()== "请选择接收客户端")
            //{
            //    cmbSessions.DroppedDown = true;
            //    return;
            //}
            //if(txtMessage.Text!="")
            //{
            //    var session = SocketHelper.appServer.GetAllSessions().Where(s => s.SN == cmbSessions.SelectedItem.ToString()).First();
            //    session.Send(txtMessage.Text);
            //}
        }

        private void btnCloseSocket_Click(object sender, EventArgs e)
        {
            SocketHelper.CloseSocket();
        }
    }
}
