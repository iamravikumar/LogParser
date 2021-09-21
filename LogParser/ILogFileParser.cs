using System.Collections.Generic;

namespace LogParser
{
    public interface ILogFileParser
    {
        IEnumerable<LogEntry> Parse(string filePath);
    }
}
