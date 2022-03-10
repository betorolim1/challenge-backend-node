using System;

namespace Backend.Shared.Logger.ErrorObject
{
    public class Error
    {
        public string ServerName { get; set; }
        public string RequestUrl { get; set; }
        public string RequestMethod { get; set; }
        public Exception Exception { get; set; }

        public override string ToString()
        {
            return $@"

[Date]                : {DateTime.Now}
[Request URL]         : {RequestUrl}
[Request Method]      : {RequestMethod}
[Server Name]         : {ServerName}
[Exception]           : {Environment.NewLine}{Exception.Message}
[StackTrace]          : {Environment.NewLine}{Exception.StackTrace}
                ";
        }
    }
}
