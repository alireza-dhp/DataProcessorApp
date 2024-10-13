using DataProcessorApp.Models;

namespace DataProcessorApp.Writers
{
    public interface IFileWriter
    {
        void WriteResults(Dictionary<int, MinMaxRecord> results, string outputFileName);
    }
}
