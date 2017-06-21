using System;

namespace MongoUtility.Common.Interfaces.Log
{
    public class LogInformation
    {
        public string Message { get; set; }
        public DateTime DateTime { get; private set; }
        public LogLevel LogLevel { get; set; }

        public LogInformation()
        {
            DateTime = DateTime.Now;
        }
    }
}