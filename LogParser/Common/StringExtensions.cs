namespace LogParser.Common
{
    public static class StringExtensions
    {
        /// <summary>
        /// Reports the zero-based index of the first occurrence of a quotation mark
        /// character in this string. The search starts at a specified character position.
        /// </summary>
        public static int IndexOfQuote(this string input, int startIndex)
        {
            return input.IndexOf('"', startIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of a white space
        /// character in this string. The search starts at a specified character position.
        /// </summary>
        public static int IndexOfSpace(this string input, int startIndex)
        {
            return input.IndexOf(' ', startIndex);
        }
    }
}
