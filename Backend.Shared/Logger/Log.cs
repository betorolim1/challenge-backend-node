using Backend.Shared.Logger.ErrorObject;
using System;
using System.Diagnostics;
using System.IO;

namespace Backend.Shared.Logger
{
    public static class Log
    {
        public static void LogError(Exception exception, string method, string url)
        {
            var obj = new Error
            {
                ServerName = Environment.MachineName,
                Exception = exception,
                RequestMethod = method,
                RequestUrl = url
            };
            Directory.CreateDirectory("Logs");

            using (StreamWriter w = File.AppendText($"Logs\\Log_Error_{DateTime.Today.ToString("dd-MM-yyyy")}_logs.txt"))
            {
                w.WriteLine(obj.ToString());
            }
        }
    }
}
