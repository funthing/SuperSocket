using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
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
    public class FunThingServer : AppServer<FunThingSession>
    {
        /// <summary>
        /// 使用配置启动服务
        /// </summary>
        /// <param name="rootConfig"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
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
