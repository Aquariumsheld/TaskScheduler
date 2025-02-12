using System.Diagnostics;

public class PreTask
{
    public string Name { get; set; }
    public Action TaskAction { get; set; }
    public DateTime ScheduledTime { get; set; }
    public int Priority { get; set; } // 1 = high, 5 = low
    public bool IsRecurring { get; set; }
    public TimeSpan? Interval { get; set; } // Für wiederkehrende Aufgaben

    public PreTask(string name, Action taskAction, DateTime scheduledTime, int priority = 3, bool isRecurring = false, TimeSpan? interval = null)
    {
        Name = name;
        TaskAction = taskAction;
        ScheduledTime = scheduledTime;
        Priority = priority;
        IsRecurring = isRecurring;
        Interval = interval;
    }

    public void Execute()
    {
        TaskAction.Invoke();
    }
}


public class OwnTask
{
    public string Name { get; set; }
    public string FilePath { get; set; }
    public DateTime ScheduledTime { get; set; }
    public int Priority { get; set; } // 1 = high, 5 = low
    public bool IsRecurring { get; set; }
    public TimeSpan? Interval { get; set; } // Für wiederkehrende Aufgaben

    public OwnTask(string name, string filePath, DateTime scheduledTime, int priority = 3, bool isRecurring = false, TimeSpan? interval = null)
    {
        Name = name;
        FilePath = filePath;
        ScheduledTime = scheduledTime;
        Priority = priority;
        IsRecurring = isRecurring;
        Interval = interval;
    }

    public void Execute()
    {
        Process.Start(FilePath);
    }
}