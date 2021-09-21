namespace LogParser
{
    public interface ILogEntryParser
    {
        LogEntry Parse(string rawLogEntry);
    }
}
