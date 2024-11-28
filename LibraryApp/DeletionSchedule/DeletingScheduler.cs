using Quartz;
using Quartz.Impl;
using QuartzApp.Jobs;

namespace LibraryApp.Jobs
{
    public class DeletingScheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<DeleteOldAccounts>().Build();

            ITrigger trigger = TriggerBuilder.Create() // creating a trigger
                  .WithIdentity("trigger1", "group1")  // identifying a trigger with a name and a group
                  .WithSchedule(CronScheduleBuilder
                  .DailyAtHourAndMinute(23, 59))
                  .StartNow()                          // start immediately after the start of execution
                  .Build();

            await scheduler.ScheduleJob(job, trigger); // starting the work
        }
    }
}