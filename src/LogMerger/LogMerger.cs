using System.Linq;

namespace LogMerger
{
    public class LogMerger
    {
        public static Log[] Merge(string[] inputPaths)
        {
            return
                inputPaths
                .SelectMany(LogReader.Read)
                .Distinct()
                .OrderBy(l => l.DateTime)
                .ThenBy(l => l.Message)
                .ToArray();
        }
    }
}
