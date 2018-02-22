using Quartz;
using SocketClient.SocketClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient.Job
{
    public class HeartBeatJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(new Action(() =>
            {
                try
                {
                    SocketClientHelper.Send("HEARTBEAT", "心跳");
                }
                //TODO:可能有多个异常，如何正确捕获SOCKET失去连接引发的异常
                catch(Exception e)
                {
                    if(e.Message.Contains("")&&!FormHelper.frm.worker.IsBusy)
                    {
                        FormHelper.DisConnect();
                        FormHelper.frm.worker.RunWorkerAsync(60);
                    }
                }
            }));
        }
    }
}
