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
    /// 客户端确认已经收到消息
    /// </summary>
    class IGET : CommandBase<FunThingSession, StringRequestInfo>
    {
        public override void ExecuteCommand(FunThingSession session, StringRequestInfo requestInfo)
        {
            //只接受一个参数
            if (requestInfo.Parameters.Count() != 1)
            {
                session.Send("参数错误\r\n");
                return;
            }
            //获取参数
            string key = requestInfo.Parameters[0];
            if (string.IsNullOrWhiteSpace(key))
            {
                session.Send("guid 不能为空\r\n");
                return;
            }

            if (key.Substring(key.Length - 1, 1) != "$")
            {
                session.Send("guid错误\r\n");
                return;
            }

            // Guid guid = new Guid(key.Substring(0, key.Length - 1));
            //确认收到消息则将此消息从消息队列中删除
            //GlobalFunThingMsgList.RemoveMsg(guid);
            session.Send("成功\r\n");


        }
    }
}
