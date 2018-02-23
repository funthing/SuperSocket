using SuperSocket.FunThingSuperSocket;
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
    public class HEARTBEAT : CommandBase<FunThingSession, MyRequestInfo>
    {
        private int Action = 2;
        public override string Name
        {
            get { return Action.ToString(); }
        }
        public override void ExecuteCommand(FunThingSession session, MyRequestInfo requestInfo)
        {
            try
            {
                if (requestInfo.Body == "心跳")
                {
                    if (!session.isLogin || string.IsNullOrWhiteSpace(session.SN))
                    {
                        var response = BitConverter.GetBytes((ushort)12).Reverse().ToList();
                        var arr = Encoding.UTF8.GetBytes("当前用户不合法");
                        response.AddRange(BitConverter.GetBytes((ushort)arr.Length).Reverse().ToArray());
                        response.AddRange(arr);
                        session.Send(response.ToArray(), 0, response.Count);
                    }
                    else
                    {
                        var response = BitConverter.GetBytes((ushort)12).Reverse().ToList();
                        var arr = Encoding.UTF8.GetBytes("OK");
                        response.AddRange(BitConverter.GetBytes((ushort)arr.Length).Reverse().ToArray());
                        response.AddRange(arr);
                        session.Send(response.ToArray(), 0, response.Count);
                        //session.Send("OK\r\n");
                        FormHelper.WriteLogToTxtLog($"收到{session.SN}的心跳");
                        session.Count = 0;
                        session.isLogin = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
