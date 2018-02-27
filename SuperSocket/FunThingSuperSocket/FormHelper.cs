using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperSocket.SuperSocket
{
    /// <summary>
    /// 跨窗体控件操作
    /// </summary>
    class FormHelper
    {
        public static frmSocketManager frm;
        /// <summary>
        /// 将信息写入到主窗体的txtLog控件中
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void WriteLogToTxtLog(string message)
        {
            /*可以使用下面的方式跨窗体传值，但是不推荐
            frmSocketManager frm = Application.OpenForms["frmSocketManager"] as frmSocketManager;
            frm.txtLog.Text+= (message + Environment.NewLine);
            */

            /*窗体指针的形式
             首先在类中定义窗体变量
             然后在窗体加载时将窗体赋值给变量
             然后在类中即可使用窗体中的控件
             */
            if (frm != null)
            {
                frm.Invoke(new Action(() =>
                {
                    frm.txtLog.Text += (message + Environment.NewLine);
                }));
            }

        }
        /// <summary>
        /// 设置dgvSessions的数据源
        /// </summary>
        /// <param name="dataSource">数据源</param>
        public static void UpdateDgvSessionsDataSource(IEnumerable<FunThingSession> dataSource)
        {
            if (frm != null)
            {
                frm.Invoke(new Action(() =>
                {
                    frm.dgvSesssions.DataSource = dataSource;
                }));
            }

        }
    }
}
