using Newtonsoft.Json;
using SocketClient.SocketClient;
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
        /// <summary>
        /// 声明接收信息的事件
        /// </summary>
        public static event ReceiveMsgHandler ReceiveMsg;
        public static Socket socketClient;

        /// <summary>
        /// 初始化服务器
        /// </summary>
        public static void InitializeServer()
        {
            try
            {
                socketClient = new Socket(SocketType.Stream, ProtocolType.Tcp);
                if (ConnectionServer())
                {
                    //从服务器端接收数据
                    Thread thread = new Thread(new ParameterizedThreadStart(Recive))
                    {
                        IsBackground = true
                    };
                    thread.Start(socketClient);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
                    InitializeServer();
                }
                string ipStr = ConfigurationManager.AppSettings["SocketIP"].ToString();
                int port = int.Parse(ConfigurationManager.AppSettings["SocketPort"].ToString());
                IPAddress ip = IPAddress.Parse(ipStr);
                IPEndPoint point = new IPEndPoint(ip, port);
                //进行连接
                socketClient.Connect(point);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("由于目标计算机积极拒绝，无法连接"))
                {
                    return false;
                }
            }
            return IsConnected();
        }

        /// <summary>
        /// 不停的接收服务器返回的信息
        /// </summary>
        /// <param name="o"></param>
        static void Recive(Object o)
        {
            //如果目标服务器关闭，只有在第二次发送数据的时候才会触发异常
            try
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
            catch (SocketException ex)
            {
                if (ex.NativeErrorCode.Equals(10053) && !FormHelper.frm.worker.IsBusy)
                {
                    FormHelper.DisConnect();
                    FormHelper.frm.worker.RunWorkerAsync(60);
                }
            }
        }

        /// <summary>
        /// 向服务器发送消息
        /// </summary>
        /// <param name="action">消息类型</param>
        /// <param name="message">消息内容</param>
        public static void Send(string action, string message)
        {
            try
            {
                if (socketClient == null)
                {
                    InitializeServer();
                }
                if(IsConnected())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes($"{action} {message} \r\n");
                    socketClient.Send(bytes);
                }
            }
            catch (SocketException ex)
            {
                if(ex.NativeErrorCode.Equals(10053)&&!FormHelper.frm.worker.IsBusy)
                {
                    FormHelper.DisConnect();
                    FormHelper.frm.worker.RunWorkerAsync(60);
                }
            }
        }

        /// <summary>
        /// 判断客户端是否正常连接到服务器
        /// </summary>
        /// <returns></returns>
        public static bool IsConnected()
        {
            bool blockingState = socketClient.Blocking;
            try
            {
                byte[] tmp = new byte[1];
                socketClient.Blocking = false;
                socketClient.Send(tmp, 0, 0);
                return true;
            }
            catch (SocketException e)
            {
                // 产生 10035 == WSAEWOULDBLOCK 错误，说明被阻止了，但是还是连接的  
                if (e.NativeErrorCode.Equals(10053))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            finally
            {
                socketClient.Blocking = blockingState;    // 恢复状态  
            }
        }
    }
}
