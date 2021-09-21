using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LogParser.Internal
{
    public class LogFileParser : ILogFileParser
    {
        private readonly ILogEntryParser _entryParser;

        public LogFileParser(ILogEntryParser entryParser)
        {
            _entryParser = entryParser;
        }

        public IEnumerable<LogEntry> Parse(string filePath)
        {
            var entries = new ConcurrentBag<LogEntry>();

            var lines = File.ReadAllLines(filePath);

            Parallel.For(0, lines.Length, x =>
            {
                entries.Add(_entryParser.Parse(lines[x]));
            });

            return entries;
        }
    }
}
