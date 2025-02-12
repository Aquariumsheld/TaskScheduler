using System.Collections.Generic;
using System.Linq;

public class TaskQueue
{
    private readonly List<PreTask> _taskQueue = new List<PreTask>();

    public void AddTask(PreTask task)
    {
        _taskQueue.Add(task);
        _taskQueue.Sort((x, y) => x.Priority.CompareTo(y.Priority)); // Priorität sortieren
    }

    public PreTask GetNextTask()
    {
        var taskToExecute = _taskQueue.FirstOrDefault();
        if (taskToExecute != null)
        {
            _taskQueue.RemoveAt(0);
        }
        return taskToExecute;
    }
}
