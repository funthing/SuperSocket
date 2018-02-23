using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket.FunThingSuperSocket
{
    public class MyRequestInfo : IRequestInfo
    {
        public MyRequestInfo(byte[] header,byte[] bodyBuffer)
        {
            //TODO:使用数字进行命令匹配
            Key =((header[0]*256)+header[1]).ToString();
            Data = bodyBuffer;
        }
        /// <summary>
        /// 用来处理消息的命令名称
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 正文字节码
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        /// 正文文本
        /// </summary>
        public string Body
        {
            get { return Encoding.UTF8.GetString(Data); }
        }
    }
}
