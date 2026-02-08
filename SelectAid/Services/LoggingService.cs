using System;
using System.IO;

namespace SelectAid.Services;

public static class LoggingService
{
    private static readonly object SyncLock = new();
    private static string? _logPath;

    public static void Initialize()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var logDirectory = Path.Combine(appData, "SelectAid");
        Directory.CreateDirectory(logDirectory);
        _logPath = Path.Combine(logDirectory, "log.txt");
    }

    public static void LogInfo(string message)
    {
        WriteLine("INFO", message);
    }

    public static void LogError(string message, Exception? exception = null)
    {
        var detail = exception == null ? message : $"{message} | {exception}";
        WriteLine("ERROR", detail);
    }

    private static void WriteLine(string level, string message)
    {
        if (string.IsNullOrWhiteSpace(_logPath))
        {
            return;
        }

        var timestamp = DateTimeOffset.Now.ToString("u");
        var line = $"{timestamp} [{level}] {message}{Environment.NewLine}";
        lock (SyncLock)
        {
            File.AppendAllText(_logPath, line);
        }
    }
}
