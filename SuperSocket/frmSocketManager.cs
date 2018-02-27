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
            dgvSesssions.AutoGenerateColumns = false;
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

        private void dgvSesssions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /* -1表示点击标题，>=0确保点击的是内容而不是标题，由于此事件是点击内容才会触发，故无需此判断
            if(e.RowIndex>=0)
            {
            }*/
            DataGridViewColumn column = dgvSesssions.Columns[e.ColumnIndex];
            DataGridViewRow row = dgvSesssions.Rows[e.RowIndex];
            string sessionID = row.Cells["SessionId"].Value.ToString();
            if (column.CellType.Name == "DataGridViewButtonCell" && column.Name == "clmOperational")
            {
                FunThingSession session = SocketHelper.appServer.GetAllSessions().Single(s => s.SessionID == sessionID);
                session.Close();
            }
        }
        
        private void dgvSesssions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSesssions.Columns[e.ColumnIndex].Name == "clmIsLogin")
            {
                if (Convert.ToBoolean(e.Value))
                {
                    e.Value = "是";
                }
                else
                {
                    e.Value = "否";
                }
            }
        }

        private void dgvSesssions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
        }
    }
}
