using DataProcessorApp.Models;

namespace DataProcessorApp.Processors
{
    public class ValueProcessor: IProcessor
    {
        public Dictionary<int, MinMaxRecord> Process(Dictionary<int, Variable> variables)
        {
            var results = new Dictionary<int, MinMaxRecord>();

            foreach (var variable in variables.Values)
            {
                MinMaxRecord minMax = variable.GetMinMax();
                results[variable.VariableID] = minMax;
            }

            return results;
        }
    }
}