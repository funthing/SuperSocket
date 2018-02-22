using Quartz;
using Quartz.Impl;
using SocketClient.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient
{
    public static class QuartzHelper
    {
        public static void Start()
        {
            try
            {
                // construct a scheduler factory
                ISchedulerFactory schedFact = new StdSchedulerFactory();

                // get a scheduler
                IScheduler sched = schedFact.GetScheduler().Result;
                sched.Start();

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<HeartBeatJob>()
                    .Build();

                // Trigger the job to run now, and then every 40 seconds
                ITrigger trigger = TriggerBuilder.Create()
                  .WithIdentity("心跳", "Socket")
                  .WithSimpleSchedule(x => x
                      .WithIntervalInSeconds(30)
                      .RepeatForever())
                  .Build();

                sched.ScheduleJob(job, trigger);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
