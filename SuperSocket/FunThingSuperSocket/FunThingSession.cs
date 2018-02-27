using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Protocol;
using System.Threading;
using SuperSocket.FunThingSuperSocket;

namespace SuperSocket.SuperSocket
{
    /// <summary>
    /// 微信Session
    /// </summary>
    public class FunThingSession:AppSession<FunThingSession,MyRequestInfo>
    {
        public FunThingSession()
        { }
        /// <summary>
        /// 是否登陆
        /// </summary>
        public bool isLogin{ get; set; }

        /// <summary>
        /// 距离最后活动时间
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 机器编码(由客户端生成)
        /// </summary>
        public string SN { get; set; }

        public string IP {
            get { return this.LocalEndPoint.ToString(); }
            set { IP = value; }
        }

        public Timer timer { get; set; }

        protected override void OnInit()
        {
            base.OnInit();
        }

        protected override void HandleUnknownRequest(MyRequestInfo requestInfo)
        {
            FormHelper.WriteLogToTxtLog("收到未知命令："+requestInfo.Key.ToString());
            this.Send(requestInfo.Key.ToString()+ "命令未定义\r\n");
        }
        /// <summary>
        /// 异常捕捉
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            this.Send("\n\r异常信息："+e.Message);
        }

        /// <summary>
        /// 连接关闭
        /// </summary>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            /*既然关闭客户端可以立即被识别到，为什么还需要心跳包？
             *在多次路由等极端情况下，此事件执行有可能会有延迟 
             * 
             */
            SocketHelper.sessions.Remove(this);
            base.OnSessionClosed(reason);

        }
    }
}
