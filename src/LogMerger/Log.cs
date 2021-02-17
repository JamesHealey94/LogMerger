using System;

namespace LogMerger
{
    public record Log
    {
        public DateTime DateTime { get; }
        public string Message { get; }

        public Log(DateTime dateTime, string message) => (DateTime, Message) = (dateTime, message);

    }
}