using Newtonsoft.Json;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SuperSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperSocket.Command
{
   public class LOGIN : CommandBase<FunThingSession, StringRequestInfo>
    {
        public override void ExecuteCommand(FunThingSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters.Count() == 1)
            {
                try
                {
                    dynamic param = JsonConvert.DeserializeObject(requestInfo.Parameters[0].ToString());
                    //已用此SN注册的连接会替换Sesion
                    var session_client = session.AppServer.GetAllSessions().Where(c => c.SN == param.SN.ToString());
                    if (session_client != null)
                    {
                        foreach (var item in session_client)
                        {
                            item.Send("您的SN已在其他地方登陆\r\n");
                            item.Close();
                        }
                    }

                    session.isLogin = true;
                    session.SN = param.SN.ToString();
                    session.Send("OK\r\n");
                    FormHelper.WriteLogToTxtLog(session.SN+"已连接");
                    session.Count = 0;
                    session.timer = new Timer(delegate {
                        session.Count++;
                        if (session.Count >= 30)
                        {
                            session.isLogin = false;
                            FormHelper.WriteLogToTxtLog($"{session.SN}已掉线");
                        }
                    }, null,0, 1000);

                }
                catch(Exception e)
                {
                    session.Send(e.Message+ "\r\n");
                }
            }
            else
            {
                session.Send("参数不合法\r\n");
            }
        }
    }
}
