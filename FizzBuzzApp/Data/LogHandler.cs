﻿using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FizzBuzzApp.Data
{
    public static class LogHandler
    {
        public static void WriteLog(string message, LogEventLevel logType, [CallerMemberName] string cmn = null)
        {
            try
            {
                var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
                var path = Path.Combine(assemblyPath, $"Log_{logType}\\{logType.ToString().ToUpper()}-{DateTime.Now:yy-MM-dd}.txt");

                message = $"\r\nMethod: {cmn}\r\nMessage: {message}\r\n_______________________________________";

                using var log = new LoggerConfiguration()
                    .WriteTo.File(path, shared: true, rollOnFileSizeLimit: true, fileSizeLimitBytes: 20971520)
                    .CreateLogger();

                switch (logType)
                {
                    case LogEventLevel.Information:
                        log.Information(message);
                        break;
                    case LogEventLevel.Warning:
                        log.Warning(message);
                        break;
                    case LogEventLevel.Error:
                        log.Error(message);
                        break;
                    case LogEventLevel.Fatal:
                        log.Fatal(message);
                        break;
                    case LogEventLevel.Verbose:
                        log.Verbose(message);
                        break;
                    case LogEventLevel.Debug:
                        log.Debug(message);
                        break;
                    default:
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            var eventLog = new EventLog
                            {
                                Source = "FizzBuzzApp"
                            };
                            eventLog.WriteEntry(message, EventLogEntryType.Information);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    var eventLog = new EventLog
                    {
                        Source = "FizzBuzzApp"
                    };
                    eventLog.WriteEntry("Error in: WriteLog.");
                    eventLog.WriteEntry($"\r\nMethod: {cmn}\r\nMessage: {message}\r\n_______________________________________\r\n");
                    eventLog.WriteEntry($"Exception encountered in {cmn}. Error: {ex.Message}\r\nDetail: {ex.StackTrace}", EventLogEntryType.Error);
                }
            }
        }
    }
}
