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
                var bodyByte = Encoding.UTF8.GetBytes("心跳");
                var rsHeart = new List<byte> { 0, 2 };
                rsHeart.AddRange(BitConverter.GetBytes((ushort)(bodyByte.Length)).Reverse().ToArray());
                rsHeart.AddRange(bodyByte);
                SocketClientHelper.socketClient.Send(rsHeart.ToArray());
            }));
        }
    }
}
