using DataProcessorApp.Models;

namespace DataProcessorApp.Writers
{
    public class TextFileWriter : IFileWriter
    {
        public void WriteResults(Dictionary<int, MinMaxRecord> results, string outputFileName)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                foreach (var result in results)
                {
                    int variableID = result.Key;
                    MinMaxRecord minMax = result.Value;
                    writer.WriteLine($"{variableID};{minMax.MinValue};{minMax.MinTimestamp};{minMax.MaxValue};{minMax.MaxTimestamp}");
                }
            }
        }
    }
}
