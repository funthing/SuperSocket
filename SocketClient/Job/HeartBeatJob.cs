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
                SocketClientHelper.Send("HEARTBEAT", "心跳");
            }));
        }
    }
}
