using FluentAssertions;
using LogParser.Internal;
using NUnit.Framework;

namespace LogParser.Tests
{
    public class LogEntryParserTests
    {
        [Test]
        public void GivenStandardLogEntry_ShouldParseCorrectly()
        {
            var rawEntry = "50.112.00.11 - admin [11/Jul/2018:17:31:56 +0200] \"GET /asset.js HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6\"";

            var parser = new LogEntryParser();

            var entry = parser.Parse(rawEntry);

            entry.Host.Should().Be("50.112.00.11");

            entry.Ident.Should().Be(string.Empty);

            entry.AuthUser.Should().Be("admin");

            entry.Request.Should().Be("GET /asset.js HTTP/1.1");

            entry.Status.Should().Be("200");

            entry.Bytes.Should().Be(3574);

            entry.Referrer.Should().Be(string.Empty);

            entry.UserAgent.Should().Be("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6");
        }

        [Test]
        public void GivenNonStandardLogEntry_ShouldParseCorrectly()
        {
            // This entry has some random numbers at the end
            var rawEntry = "168.41.191.9 - - [09/Jul/2018:22:56:45 +0200] \"GET /docs/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (X11; Linux i686; rv:6.0) Gecko/20100101 Firefox/6.0\" 456 789";

            var parser = new LogEntryParser();

            var entry = parser.Parse(rawEntry);

            entry.UserAgent.Should().Be("Mozilla/5.0 (X11; Linux i686; rv:6.0) Gecko/20100101 Firefox/6.0");
        }
    }
}
