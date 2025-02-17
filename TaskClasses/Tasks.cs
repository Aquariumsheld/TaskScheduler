using System.Diagnostics;


namespace TaskClasses;


/// <summary>
/// Vorgefertigte Tasks
/// </summary>
public class PreTask : MainTask
{
    /// <summary>
    /// Action der vorgefertigten Task.
    /// </summary>
    public Action TaskAction { get; set; }

    /// <summary>
    /// Konstruktor einer vorgefertigten Task.
    /// </summary>
    public PreTask(string name, Action taskAction, DateTime scheduledTime, int priority = 3, bool isRecurring = false, TimeSpan? interval = null)
    {
        Name = name;
        TaskAction = taskAction;
        ScheduledTime = scheduledTime;
        Priority = priority;
        IsRecurring = isRecurring;
        Interval = interval;
    }

    /// <summary>
    /// Führt die Action der Task aus.
    /// </summary>
    public override void Execute()
    {
        TaskAction.Invoke();
    }
}

/// <summary>
/// Individuelle / eigene Task.
/// </summary>
public class OwnTask : MainTask
{
    /// <summary>
    /// Dateipfad der eigenen Task.
    /// </summary>
    public string FilePath { get; set; }

    /// <summary>
    /// Konstruktor der eigenen Task.
    /// </summary>
    public OwnTask(string name, string filePath, DateTime scheduledTime, int priority = 3, bool isRecurring = false, TimeSpan? interval = null)
    {
        Name = name;
        FilePath = filePath;
        ScheduledTime = scheduledTime;
        Priority = priority;
        IsRecurring = isRecurring;
        Interval = interval;
    }

    /// <summary>
    /// Führt die ausgewählte .exe-Datei der Task aus.
    /// </summary>
    public override void Execute()
    {
        Process.Start(FilePath);
    }
}