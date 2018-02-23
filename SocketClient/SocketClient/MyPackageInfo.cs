using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient.SocketClient
{
    public class MyPackageInfo : IPackageInfo
    {
        public MyPackageInfo(byte[] header, byte[] bodyBuffer)
        {
            Header = header;
            Data = bodyBuffer;
        }
        /// <summary>
        /// 服务器返回的字节数据头部
        /// </summary>
        public byte[] Header { get; set; }
        /// <summary>
        /// 服务器返回的字节数据
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        /// 服务器返回的字符串数据
        /// </summary>
        public string Body
        {
            get
            {
                return Encoding.UTF8.GetString(Data);
            }
        }
    }
}
