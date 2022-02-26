using Business.Tasks.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace Business.Tasks.Triggers
{
    public class SubscribeKlineDataTrigger
    {
        private IScheduler StartJob()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            Task<IScheduler> sched = schedFact.GetScheduler();

            if (!sched.Result.IsStarted)
            {
                sched.Result.Start();
            }

            return sched.Result;
        }

        public void TriggerTheJob()
        {
            IScheduler sched = StartJob();

            IJobDetail task = JobBuilder.Create<SubscribeKlineDataJob>().WithIdentity("SubscribeKlineDataJob", null).Build();

            ISimpleTrigger triggerKlineData = (ISimpleTrigger)TriggerBuilder.Create().WithIdentity("SubscribeKlineDataJob").StartAt(DateTime.UtcNow).WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever()).Build();
            sched.ScheduleJob(task, triggerKlineData);
        }
    }
}
