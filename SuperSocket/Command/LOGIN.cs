using Newtonsoft.Json;
using SuperSocket.FunThingSuperSocket;
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
    public class LOGIN : CommandBase<FunThingSession, MyRequestInfo>
    {
        private int Action = 1;
        public override string Name
        {
            get { return Action.ToString(); }
        }
        public override void ExecuteCommand(FunThingSession session, MyRequestInfo requestInfo)
        {

            try
            {
                dynamic param = JsonConvert.DeserializeObject(requestInfo.Body);
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
                SocketHelper.sessions.Add(session);
                var response = BitConverter.GetBytes((ushort)12).Reverse().ToList();
                var arr = Encoding.UTF8.GetBytes("OK");
                response.AddRange(BitConverter.GetBytes((ushort)arr.Length).Reverse().ToArray());
                response.AddRange(arr);
                session.Send(response.ToArray(), 0, response.Count);

                FormHelper.WriteLogToTxtLog(session.SN + "已连接");
                session.Count = 0;
                session.timer = new Timer(delegate
                {
                    session.Count++;
                    if (session.Count >= 30)
                    {
                        session.isLogin = false;
                        FormHelper.WriteLogToTxtLog($"{session.SN}已掉线");
                    }
                }, null, 0, 1000);
                //TODO:更新主页面dgvSessions列表、
                FormHelper.WriteLogToTxtLog(SocketHelper.sessions.Count().ToString());
                FormHelper.UpdateDgvSessionsDataSource(SocketHelper.sessions);
            }
            catch (Exception e)
            {
                var response = BitConverter.GetBytes((ushort)12).Reverse().ToList();
                var arr = Encoding.UTF8.GetBytes(e.Message);
                response.AddRange(BitConverter.GetBytes((ushort)arr.Length).Reverse().ToArray());
                response.AddRange(arr);
                session.Send(response.ToArray(), 0, response.Count);
            }
        }
    }
}
