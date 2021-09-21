using FluentAssertions;
using LogParser.Converters;
using NUnit.Framework;

namespace LogParser.Tests.Converters
{
    public class StringConverterTests
    {
        [Test]
        public void ConvertFromStringTest()
        {
            var converter = new StringConverter();

            var input = "Test";

            var result = converter.ConvertFrom(input);

            result.Should().Be(input);
        }

        [Test]
        public void ConvertFromNullStringTest()
        {
            var converter = new StringConverter();

            var result = converter.ConvertFrom(null);

            result.Should().Be(string.Empty);
        }

        [Test]
        public void ConvertFromHypenStringTest()
        {
            var converter = new StringConverter();

            var result = converter.ConvertFrom("-");

            result.Should().Be(string.Empty);
        }
    }
}
