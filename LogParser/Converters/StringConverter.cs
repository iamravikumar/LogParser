namespace LogParser.Converters
{
    public class StringConverter
    {
        public string ConvertFrom(string input)
        {
            if (input == null || input == "-")
            {
                return string.Empty;
            }

            return input;
        }
    }
}
