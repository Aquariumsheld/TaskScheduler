using System;
using System.IO;

public class Logger
{
    private readonly string _logFilePath;

    public Logger(string logFilePath)
    {
        _logFilePath = logFilePath;

        if (!File.Exists(_logFilePath))
        {
            using (var writer = new StreamWriter(_logFilePath, append: false))
            {
                writer.WriteLine("Timestamp,TaskName,Message");  // CSV-Header
            }
        }
    }

    public void Log(string taskName, string message)
    {
        string logEntry = $"{DateTime.Now},{taskName},{message}";

        using (var writer = new StreamWriter(_logFilePath, append: true))
        {
            writer.WriteLine(logEntry);
        }
    }
}
