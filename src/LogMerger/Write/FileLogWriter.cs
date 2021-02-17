using System.IO;
using System.Linq;

namespace LogMerger
{
    public class FileLogWriter : ILogWriter
    {
        public void Write(Log[] input)
        {
            Write("output.txt", input);
        }

        public static void Write(string outputPath, Log[] input)
        {
            File.WriteAllLines(outputPath, input.Select(i => $"{i.DateTime:yyyy-MM-dd HH:mm:ss.fff} {i.Message}"));
        }
    }
}