using System;
using FluentAssertions;
using LogParser.Converters;
using NUnit.Framework;

namespace LogParser.Tests.Converters
{
    public class DateTimeOffsetConverterTests
    {
        [Test]
        public void ConvertFromStringTest()
        {
            var input = "09/Jul/2018:22:56:45 +0200";

            var converter = new DateTimeOffsetConverter();

            var result = converter.ConvertFrom(input);

            result.Day.Should().Be(9);
            result.Month.Should().Be(7);
            result.Year.Should().Be(2018);
            result.Hour.Should().Be(22);
            result.Minute.Should().Be(56);
            result.Second.Should().Be(45);
            result.Offset.Should().Be(TimeSpan.FromHours(2));
        }
    }
}
