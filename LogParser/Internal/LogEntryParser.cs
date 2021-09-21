using System;
using LogParser.Common;
using LogParser.Converters;

namespace LogParser.Internal
{
    public class LogEntryParser : ILogEntryParser
    {
        private readonly StringConverter _stringConverter;
        private readonly DateTimeOffsetConverter _dateTimeOffsetConverter;
        private readonly Int32Converter _intConverter;

        public LogEntryParser()
        {
            _stringConverter = new StringConverter();
            _dateTimeOffsetConverter = new DateTimeOffsetConverter();
            _intConverter = new Int32Converter();
        }

        public LogEntry Parse(string input)
        {
            var entry = new LogEntry();

            var startIndex = 0;
            var endIndex = 0;

            entry.Host = ParseHost(input, ref startIndex, ref endIndex);
            entry.Ident = ParseIdent(input, ref startIndex, ref endIndex);
            entry.AuthUser = ParseAuthUser(input, ref startIndex, ref endIndex);
            entry.Date = ParseDate(input, ref startIndex, ref endIndex);
            entry.Request = ParseRequest(input, ref startIndex, ref endIndex);
            entry.Status = ParseStatus(input, ref startIndex, ref endIndex);
            entry.Bytes = ParseBytes(input, ref startIndex, ref endIndex);
            entry.Referrer = ParseReferrer(input, ref startIndex, ref endIndex);
            entry.UserAgent = ParseUserAgent(input, ref startIndex, ref endIndex);

            return entry;
        }

        private string ParseHost(string input, ref int startIndex, ref int endIndex)
        {
            startIndex = 0;

            endIndex = input.IndexOfSpace(startIndex);

            return _stringConverter.ConvertFrom(input[startIndex..endIndex]);
        }

        private string ParseIdent(string input, ref int startIndex, ref int endIndex)
        {
            startIndex = endIndex + 1; // Skip space

            endIndex = input.IndexOfSpace(startIndex);

            return _stringConverter.ConvertFrom(input[startIndex..endIndex]);
        }

        private string ParseAuthUser(string input, ref int startIndex, ref int endIndex)
        {
            startIndex = endIndex + 1; // Skip space

            endIndex = input.IndexOfSpace(startIndex);

            return _stringConverter.ConvertFrom(input[startIndex..endIndex]);
        }

        private DateTimeOffset ParseDate(string input, ref int startIndex, ref int endIndex)
        {
            startIndex = endIndex + 2; // Skip space and [

            endIndex = startIndex + 26;

            return _dateTimeOffsetConverter.ConvertFrom(input[startIndex..endIndex]);
        }

        private string ParseRequest(string input, ref int startIndex, ref int endIndex)
        {
            startIndex = endIndex + 3; // Skip ], space and "

            endIndex = input.IndexOfQuote(startIndex);

            return _stringConverter.ConvertFrom(input[startIndex..endIndex]);
        }

        private string ParseStatus(string input, ref int startIndex, ref int endIndex)
        {
            startIndex = endIndex + 2; // Skip " and space

            endIndex = startIndex + 3;

            return _stringConverter.ConvertFrom(input[startIndex..endIndex]);
        }

        private int ParseBytes(string input, ref int startIndex, ref int endIndex)
        {
            startIndex += 4; // Skip status code and space

            endIndex = input.IndexOfSpace(startIndex);

            return _intConverter.ConvertFrom(input[startIndex..endIndex]);
        }

        private string ParseReferrer(string input, ref int startIndex, ref int endIndex)
        {
            startIndex = endIndex + 2; // Skip space and "

            endIndex = input.IndexOfQuote(startIndex);

            return _stringConverter.ConvertFrom(input[startIndex..endIndex]);
        }

        private string ParseUserAgent(string input, ref int startIndex, ref int endIndex)
        {
            startIndex = endIndex + 3; // Skip ", space, and "

            endIndex = input.IndexOfQuote(startIndex);

            return _stringConverter.ConvertFrom(input[startIndex..endIndex]);
        }
    }
}
