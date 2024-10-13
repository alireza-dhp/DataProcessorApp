using DataProcessorApp.Models;

namespace DataProcessorApp.Parsers
{
    public interface IFileParser
    {
        Dictionary<int, Variable> ParseFile(string fileName);
    }
}
