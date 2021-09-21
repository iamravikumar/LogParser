using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using LogParser.Internal;

namespace LogParser.Performance
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class LogParserBenchmarks
    {
        private readonly string _logFilePath = "sample.log";

        [Benchmark(Baseline = true)]
        public void ParseSampleLog()
        {
            var logEntryParser = new LogEntryParser();

            var logFileParser = new LogFileParser(logEntryParser);

            logFileParser.Parse(_logFilePath);
        }
    }
}
