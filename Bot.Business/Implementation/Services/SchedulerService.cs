using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bot.Business.Implementation.Services
{
    public class SchedulerService
    {
        private static SchedulerService _instance;
        private List<Timer> timers = new List<Timer>();
        private SchedulerService() { }
        public static SchedulerService Instance => _instance ?? (_instance = new SchedulerService());

        public void ScheduleTask(long duration, Action task)
        {
            TimeSpan timeToGo = TimeSpan.FromSeconds(duration);
            if (timeToGo <= TimeSpan.Zero)
            {
                timeToGo = TimeSpan.Zero;
            }
            var timer = new Timer(x =>
            {
                task.Invoke();
            }, null, timeToGo, Timeout.InfiniteTimeSpan);
            timers.Add(timer);
        }
    }
}
