using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SuperSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket.Command
{
    /// <summary>
    /// 心跳包（客户端发送参数&，服务器端返回参数$）
    /// </summary>
    public class HEARTBEAT : CommandBase<FunThingSession, StringRequestInfo>
    {
        public override void ExecuteCommand(FunThingSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters.Count() == 1)
            {
                if (requestInfo.Parameters[0] == "心跳")
                {
                    if (!session.isLogin || string.IsNullOrWhiteSpace(session.SN))
                    {
                        session.Send("当前用户不合法\r\n");
                     }
                    else
                    { 
                        session.Send("OK\r\n");
                        FormHelper.WriteLogToTxtLog($"收到{session.SN}的心跳");
                        session.Count = 0;
                        session.isLogin = true;
                    }
                }
            }
        }
    }
}
