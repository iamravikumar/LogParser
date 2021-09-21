namespace LogParser
{
    public interface ILogEntryParser
    {
        LogEntry Parse(string input);
    }
}
