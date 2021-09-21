using System;
using System.Globalization;

namespace LogParser.Converters
{
    public class DateTimeOffsetConverter
    {
        public static string _format = "dd/MMM/yyyy:HH:mm:ss zzz";

        public DateTimeOffset ConvertFrom(string input)
        {
            return DateTimeOffset.ParseExact(input, _format, CultureInfo.InvariantCulture);
        }
    }
}
