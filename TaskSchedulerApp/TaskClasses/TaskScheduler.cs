using System;
using System.Threading;

public class TaskScheduler
{
    private readonly TaskQueue _taskQueue = new TaskQueue();

    public void ScheduleTask(PreTask task)
    {
        _taskQueue.AddTask(task);
    }

    public async Task Start()
    {
        while (true)
        {
            var nextTask = _taskQueue.GetNextTask();
            if (nextTask != null)
            {
                var delay = nextTask.ScheduledTime - DateTime.Now;
                if (delay.TotalMilliseconds > 0)
                {
                    Thread.Sleep(delay);
                }

                nextTask.Execute();

                if (nextTask.IsRecurring && nextTask.Interval.HasValue)
                {
                    nextTask.ScheduledTime = DateTime.Now.Add(nextTask.Interval.Value); // Neu planen
                    ScheduleTask(nextTask); // Wieder hinzufügen
                }
            }
        }
    }
}
