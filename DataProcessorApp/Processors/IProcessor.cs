using DataProcessorApp.Models;

namespace DataProcessorApp.Processors
{
    public interface IProcessor
    {
        Dictionary<int, MinMaxRecord> Process(Dictionary<int, Variable> variables);
    }
}
