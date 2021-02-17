using System;

namespace LogMerger.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputPath = args[0];
            var inputPaths = args[1..];
            Console.WriteLine("Merging files: " + string.Join(", ", inputPaths) + "...");
            var logs = LogMerger.Merge(inputPaths);
            FileLogWriter.Write(outputPath, logs);
            Console.WriteLine("Output to " + outputPath);
        }
    }
}
