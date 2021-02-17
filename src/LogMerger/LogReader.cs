using System;
using System.IO;
using System.Linq;

namespace LogMerger
{
    public class LogReader
    {
        // Example line: 2018-06-29 14:14:46.675 Hello Refract!
        private readonly static int DateStringLength = "2018-06-29 14:14:46.675".Length;

        public static Log[] Read(string inputPath)
        {
            try
            {
                var lines = File.ReadAllLines(inputPath);
                return lines.Select(l =>
                {
                    return new Log
                    (
                        DateTime.Parse(l.Substring(0, DateStringLength)),
                        l.Substring(DateStringLength + 1) // +1 to account for the space
                    );
                }).ToArray();
            }
            catch
            {
                Console.WriteLine($"Exception reading file: '{inputPath}' - Ignoring");
                return Array.Empty<Log>();
            }
        }
    }
}