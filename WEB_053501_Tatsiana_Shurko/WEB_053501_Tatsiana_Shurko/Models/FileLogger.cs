using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using WEB_053501_Tatsiana_Shurko.Controllers;

namespace WEB_053501_Tatsiana_Shurko.Models {
    public class FileLogger : ILogger {
        private string filePath;
        private static object _lock = new object();
        public FileLogger(string path) {
            filePath = path;
        }
        public IDisposable BeginScope<TState>(TState state) {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel) {
            //return logLevel == LogLevel.Trace;
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            if (formatter != null) {
                lock (_lock) {
                    File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
    public class FileLoggerProvider : ILoggerProvider {
        private string path;
        public FileLoggerProvider(string _path) {
            path = _path;
        }
        public ILogger CreateLogger(string categoryName) {
            return new FileLogger(path);
        }

        public void Dispose() {
        }
    }
    public static class FileLoggerExtensions {
        public static ILoggerFactory AddFile(this ILoggerFactory factory,
                                        string filePath) {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }

 
public class LogMiddleware {
        private readonly RequestDelegate _next;        

        public LogMiddleware(RequestDelegate next) {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILoggerFactory loggerFactory) {
            await _next.Invoke(context);

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
            if (context.Response.StatusCode != 200) {
                logger.LogInformation($"{DateTime.Today}: {context.Request.Path}  -- {context.Request.QueryString} --  {context.Response.StatusCode}");
            }
        }
    }
}