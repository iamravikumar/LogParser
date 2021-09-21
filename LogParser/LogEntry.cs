using System;

namespace LogParser
{
    public class LogEntry
    {
        public string Host { get; set; }
        public string Ident { get; set; }
        public string AuthUser { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Request { get; set; }
        public string Status { get; set; }
        public long Bytes { get; set; }
        public string Referrer { get; set; }
        public string UserAgent { get; set; }
    }
}
