using Newtonsoft.Json;
using SocketClient.SocketClient;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketClient
{
    public delegate void ReceiveMsgHandler(string msg);
    static class SocketClientHelper
    {
        //变量添加get和set可以对读写权限进行控制，以及检验设置的值是否符合要求，如果无上述需求，可省略
        public static EasyClient<MyPackageInfo> socketClient;

        /// <summary>
        /// 连接到服务器
        /// </summary>
        /// <returns></returns>
        public static bool ConnectionServer()
        {
            try
            {
                if (socketClient == null)
                {
                    socketClient = new EasyClient<MyPackageInfo>();
                    socketClient.Initialize(new MyReceiveFilter());
                }
                string ipStr = ConfigurationManager.AppSettings["SocketIP"].ToString();
                int port = int.Parse(ConfigurationManager.AppSettings["SocketPort"].ToString());
                IPAddress ip = IPAddress.Parse(ipStr);
                IPEndPoint point = new IPEndPoint(ip, port);
                //进行连接
                var connected = socketClient.ConnectAsync(point).Result;
            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }

        /// <summary>
        /// 向服务器发送消息
        /// </summary>
        /// <param name="action">消息类型</param>
        /// <param name="message">消息内容</param>
        public static void Send(string action, string message)
        {
            if (socketClient.IsConnected&&socketClient!=null)
            {
                byte[] bytes = Encoding.UTF8.GetBytes($"{action} {message} \r\n");
                socketClient.Send(bytes);
            }
            else if(!FormHelper.frm.worker.IsBusy)
            {
                FormHelper.DisConnect();
                FormHelper.frm.worker.RunWorkerAsync(60);
            }
        }
    }
}
