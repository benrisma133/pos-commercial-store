using System;
using System.IO;
using System.Text;

namespace Repository.Loggers
{
    public static class clsLog
    {
        // ── Configuration ─────────────────────────────────────────────────────
        private static readonly string _logDirectory =
            Path.Combine(FileSystem.AppDataDirectory, "Logs");

        // One file per day: Logs/2025-07-21.log
        private static string LogFilePath =>
            Path.Combine(_logDirectory, $"{DateTime.UtcNow:yyyy-MM-dd}.log");

        private static readonly object _lock = new object();

        // ── Core writer ───────────────────────────────────────────────────────
        private static void WriteToFile(string level, string entry)
        {
            try
            {
                lock (_lock)
                {
                    Directory.CreateDirectory(_logDirectory);
                    File.AppendAllText(LogFilePath, entry + Environment.NewLine, Encoding.UTF8);
                }
            }
            catch
            {
                // Logger must never crash the app — swallow silently
            }
        }

        // ── Builders ──────────────────────────────────────────────────────────
        private static string BuildErrorLog(string className, string methodName, Exception ex)
        {
            return new StringBuilder()
                .Append($"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC] ")
                .Append("[ERROR] ")
                .Append($"[{className}.{methodName}] ")
                .Append($"{ex.GetType().Name}: {ex.Message}")
                .AppendLine()
                .Append($"    StackTrace: {ex.StackTrace}")
                .ToString();
        }

        private static string BuildInfoLog(string className, string methodName, string message)
        {
            return new StringBuilder()
                .Append($"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC] ")
                .Append("[INFO]  ")
                .Append($"[{className}.{methodName}] ")
                .Append(message)
                .ToString();
        }

        // ── Public API ────────────────────────────────────────────────────────
        public static void LogError(string className, string methodName, Exception ex)
        {
            string entry = BuildErrorLog(className, methodName, ex);
            WriteToFile("ERROR", entry);
            #if DEBUG
                System.Diagnostics.Debug.WriteLine(entry);
            #endif
        }

        public static void LogInfo(string className, string methodName, string message)
        {
            string entry = BuildInfoLog(className, methodName, message);
            WriteToFile("INFO", entry);
        }
    
    }
}