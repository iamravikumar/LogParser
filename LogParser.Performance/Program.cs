using BenchmarkDotNet.Running;

namespace LogParser.Performance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<LogParserBenchmarks>();
        }
    }
}
