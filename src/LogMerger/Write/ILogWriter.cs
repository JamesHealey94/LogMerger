namespace LogMerger
{
    public interface ILogWriter
    {
        public void Write(Log[] input);
    }
}