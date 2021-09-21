using FluentAssertions;
using LogParser.Converters;
using NUnit.Framework;

namespace LogParser.Tests.Converters
{
    public class Int32ConverterTests
    {

        [Test]
        public void ConvertFromStringTest()
        {
            var converter = new Int32Converter();

            var input = "777";

            var result = converter.ConvertFrom(input);

            result.Should().Be(777);
        }
    }
}
