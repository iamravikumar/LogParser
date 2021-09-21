using System.Linq;
using FluentAssertions;
using LogParser.Internal;
using NUnit.Framework;

namespace LogParser.Tests
{
    public class LogFileParserTests
    {
        private LogFileParser _logFileParser;

        private readonly string _logFilePath = "test-data.log";

        [SetUp]
        public void SetUp()
        {
            _logFileParser = new LogFileParser(new LogEntryParser());
        }

        [Test]
        public void GivenValidLogFile_ShouldParseAllEntries()
        {
            var entries = _logFileParser.Parse(_logFilePath);

            entries.Should().NotBeEmpty();

            entries.Should().HaveCount(10);
        }

        [Test]
        public void GivenValidLogFile_ShouldReturnNumberOfUniqueIpAddresses()
        {
            var entries = _logFileParser.Parse(_logFilePath);

            var result = entries
                .Select(e => e.Host)
                .Distinct()
                .Count();

            result.Should().Be(4);
        }

        [Test]
        public void GivenValidLogFile_ShouldReturnTop3MostVisitedUrls()
        {
            var entries = _logFileParser.Parse(_logFilePath);

            var results = entries
                .GroupBy(g => g.Request)
                .Select(r => new { Request = r.Key, Visits = r.Count() })
                .OrderByDescending(r => r.Visits)
                .Take(3)
                .Select(r => r.Request)
                .ToList();

            results.Should().Contain("GET /home/ HTTP/1.1");
            results.Should().Contain("GET /counter/ HTTP/1.1");
            results.Should().Contain("GET /fetch-data/ HTTP/1.1");
        }

        [Test]
        public void GivenValidLogFile_ShouldReturnTop3MostActiveIpAddresses()
        {
            var entries = _logFileParser.Parse(_logFilePath);

            var results = entries
                .GroupBy(g => g.Host)
                .Select(r => new { IpAddress = r.Key, Requests = r.Count() })
                .OrderByDescending(r => r.Requests)
                .Take(3)
                .Select(r => r.IpAddress)
                .ToList();

            results.Should().Contain("1.1.1.1");
            results.Should().Contain("1.1.1.2");
            results.Should().Contain("1.1.1.3");
        }
    }
}
