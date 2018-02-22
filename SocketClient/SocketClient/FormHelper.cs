using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient.SocketClient
{
    /// <summary>
    /// 跨窗体控件操作
    /// </summary>
    class FormHelper
    {
        public static FrmShowMsg frm;
        /// <summary>
        /// 当客户端与服务器断开连接时执行事件
        /// </summary>
        public static void DisConnect()
        {
            /*窗体指针的形式
             首先在类中定义窗体变量
             然后在窗体加载时将窗体赋值给变量
             然后在类中即可使用窗体中的控件
             */
            if (frm != null)
            {
                frm.Invoke(new Action(() =>
                {
                    frm.txtReciveMsg.Text += $"已经与服务器断开连接{Environment.NewLine}";
                    frm.lblState.Text = "掉线";
                    frm.lblState.ForeColor = Color.Red;
                    frm.lblAutoReconnention.Visible = true;
                    frm.linklblConnention.Visible = true;
                }));
            }

        }

        /// <summary>
        /// 当客户端与服务器连接时执行事件
        /// </summary>
        public static void IsConnect()
        {
            /*窗体指针的形式
             首先在类中定义窗体变量
             然后在窗体加载时将窗体赋值给变量
             然后在类中即可使用窗体中的控件
             */
            if (frm != null)
            {
                frm.Invoke(new Action(() =>
                {
                    frm.txtReciveMsg.Text += $"已经连接到服务器{Environment.NewLine}";
                    frm.lblState.Text = "在线";
                    frm.lblState.ForeColor = Color.Blue;
                    frm.lblAutoReconnention.Visible = false;
                    frm.linklblConnention.Visible = false;
                }));
            }

        }
    }
}
