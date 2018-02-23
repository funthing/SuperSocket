using SuperSocket.FunThingSuperSocket;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket.SuperSocket
{
    /// <summary>
    /// 微信服务
    /// </summary>
    public class FunThingServer : AppServer<FunThingSession,MyRequestInfo>
    {
        public FunThingServer():base(new DefaultReceiveFilterFactory<MyReceiveFilter,MyRequestInfo>())
        {

        }

        protected override void OnStarted()
        {
            FormHelper.WriteLogToTxtLog("FunThing服务启动成功");
            base.OnStarted();

        }

        protected override void OnStopped()
        {
            FormHelper.WriteLogToTxtLog("FunThing服务停止成功");
            base.OnStopped();
        }

    }
}
