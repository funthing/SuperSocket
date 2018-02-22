using SuperSocket.CustomerException;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket.SuperSocket
{
    static class SocketHelper
    {
        public static FunThingServer appServer=null;
        public static IBootstrap _bootstrap;
        /// <summary>
        /// 开启Socket服务并绑定相关事件
        /// 监听服务即为AppServer
        /// 客户端连接为Session
        /// </summary>
        public static void openSocket()
        {
            try
            {
                int port = int.Parse(ConfigurationManager.AppSettings["SuperSocketPort"]);
                var config = new SocketBase.Config.ServerConfig()
                {
                    Name="繁星服务端",
                    ServerTypeName="繁星服务端",
                    Ip="Any",
                    Port= port,
                    MaxConnectionNumber=10000,
                    MaxRequestLength=2048,
                    IdleSessionTimeOut=90,
                    ClearIdleSession=true,
                    ClearIdleSessionInterval=60,
                    TextEncoding = "UTF-8"
                };
                appServer = new FunThingServer();
                if(!appServer.Setup(config))
                {
                    FormHelper.WriteLogToTxtLog("创建服务失败");
                }
                if(!appServer.Start())
                {
                    FormHelper.WriteLogToTxtLog("启动失败");
                }
                
            }
            catch (FormatException)
            {

                FormHelper.WriteLogToTxtLog("IP端口号错误，仅支持数字");
            }
        }
        public static void CloseSocket()
        {
            switch(appServer.State)
            {
                case ServerState.NotStarted:
                    FormHelper.WriteLogToTxtLog("服务未启动，无需关闭");
                    break;
                case ServerState.Stopping:
                    FormHelper.WriteLogToTxtLog("服务正在关闭，请等待");
                    break;
                case ServerState.Initializing:
                    FormHelper.WriteLogToTxtLog("服务正在初始化，请等待初始化完成");
                    break;
                case ServerState.Running:
                    appServer.Stop();
                    if(appServer.State!=ServerState.NotStarted)
                    {
                        FormHelper.WriteLogToTxtLog("服务关闭失败，请重试");
                    }
                    break;
            }
        }
    }
}
