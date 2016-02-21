using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using XinemaProject.Controllers;

namespace XinemaProject.App_Start
{
    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<DataJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                // Actual code for run job every 24 hours
                //.WithDailyTimeIntervalSchedule
                //  (s =>
                //     s.WithIntervalInHours(24)
                //    .OnEveryDay()
                //    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))
                //  )
                //.Build();


                // Code for testing
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}