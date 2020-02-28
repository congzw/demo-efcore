using System;
using Microsoft.Extensions.Logging;

namespace Foo.App.Boots
{
    public class MyLogProvider : ILoggerProvider
    {
        public void Dispose()
        {

        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger();
        }
    }

    public class Logger : ILogger
    {
        public static bool Enable { get; set; }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!Enable)
            {
                return;
            }

            var logMessage = formatter(state, exception);
            if (logMessage.Contains("SELECT ") || logMessage.Contains("INSERT ") || logMessage.Contains("UPDATE ") || logMessage.Contains("DELETE "))
            {
                Console.WriteLine(logMessage);
            }
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
