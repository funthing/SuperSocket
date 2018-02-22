using Newtonsoft.Json;
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
    //声明接收信息的委托
    public delegate void ReceiveMsgHandler(string msg);
    static class SocketClientHelper
    {
        public static event ReceiveMsgHandler ReceiveMsg;
        public static Socket socketClient;

        public static void InitializeServer()
        {
            try
            {
                socketClient = new Socket(SocketType.Stream, ProtocolType.Tcp);
                ConnectionServer();

                //从服务器端接收数据
                Thread thread = new Thread(new ParameterizedThreadStart(Recive))
                {
                    IsBackground = true
                };
                thread.Start(socketClient);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ConnectionServer()
        {
            if (socketClient == null)
            {
                InitializeServer();
            }
            if(!socketClient.Connected)
            {
                string ipStr = ConfigurationManager.AppSettings["SocketIP"].ToString();
                int port = int.Parse(ConfigurationManager.AppSettings["SocketPort"].ToString());
                IPAddress ip = IPAddress.Parse(ipStr);
                IPEndPoint point = new IPEndPoint(ip, port);
                //进行连接
                socketClient.Connect(point);
                return socketClient.Connected;
            }
            return socketClient.Connected;
        }

        static void Recive(Object o)
        {
            var send = o as Socket;
            while (true)
            {
                //获取发送过来的消息
                byte[] buffer = new byte[1024 * 1024 * 2];
                var effective = send.Receive(buffer);
                if (effective == 0)
                {
                    break;
                }
                var str = Encoding.UTF8.GetString(buffer, 0, effective);
                ReceiveMsg(str);
            }
        }

        public static void Send(string action, string message)
        {
            if (socketClient == null)
            {
                InitializeServer();
            }
            if (!socketClient.Connected)
            {
                ConnectionServer();
            }
            byte[] bytes= Encoding.UTF8.GetBytes($"{action} {message} \r\n");
            socketClient.Send(bytes);
        }

        public static bool IsConnected()
        {
            bool isConnected = false;
            if(socketClient.Poll(-1,SelectMode.SelectRead))
            {
                byte[] temp = new byte[1024];
                int nRead = socketClient.Receive(temp);
                if(nRead!=0)
                {
                    isConnected = true;
                }
            }
            return isConnected;
        }
    }
}
