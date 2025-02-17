using System.Collections.Generic;
using System.Linq;
using TaskClasses;

/// <summary>
/// "Warteschlange" für alle Tasks.
/// </summary>
public class TaskQueue
{
    /// <summary>
    /// Liste mit allen Tasks.
    /// </summary>
    private readonly List<MainTask> _taskQueue = new List<MainTask>();

    /// <summary>
    /// Fügt eine Task hinzu und sortiert anschließen die gesamte Liste nach Priorität.
    /// </summary>
    /// <param name="task">Hinzuzufügende Task</param>
    public void AddTask(MainTask task)
    {
        _taskQueue.Add(task);
        _taskQueue.Sort((x, y) => x.Priority.CompareTo(y.Priority)); // Priorität sortieren
    }

    /// <summary>
    /// Gibt die nächste ausstehende Task der Liste zurück.
    /// </summary>
    /// <returns>Nächste ausstehende Task</returns>
    public MainTask? GetNextTask()
    {
        var taskToExecute = _taskQueue.FirstOrDefault();
        if (taskToExecute != null)
        {
            _taskQueue.RemoveAt(0);
        }
        return taskToExecute;
    }
}
