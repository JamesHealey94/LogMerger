using System;

namespace LogMerger
{
    public class FileLogWriter : ILogWriter
    {
        public void Write(Log[] input)
        {
            Write("output.txt", input);
        }

        public void Write(string outputPath, Log[] input)
        {
            throw new NotImplementedException();
        }
    }
}