using DataProcessorApp.Models;
using System.Globalization;

namespace DataProcessorApp.Parsers
{
    public class TextFileParser : IFileParser
    {
        public Dictionary<int, Variable> ParseFile(string fileName)
        {
            var variables = new Dictionary<int, Variable>();
            var channelMapping = new Dictionary<int, int>(); // channel to variableID mapping
            bool parsingVariables = false, parsingValues = false;

            foreach (var line in File.ReadLines(fileName))
            {
                if (line.StartsWith("-VARIABLES-"))
                {
                    parsingVariables = true;
                    parsingValues = false;
                    continue;
                }
                if (line.StartsWith("-VALUES-"))
                {
                    parsingVariables = false;
                    parsingValues = true;
                    continue;
                }

                if (parsingVariables)
                {
                    var parts = line.Split('=');
                    int channelIndex = int.Parse(parts[0].TrimStart('@'));
                    int variableID = int.Parse(parts[1]);
                    channelMapping[channelIndex] = variableID;
                    variables[variableID] = new Variable(variableID);
                }

                if (parsingValues)
                {
                    // Step 1: Split on the first `:`
                    var firstSplit = line.Split(new char[] { '@', ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    int channelIndex = int.Parse(firstSplit[0]);

                    // Step 2: Split the remaining part on `;` to extract value, status, and timestamp
                    var secondSplit = firstSplit[1].Split(';', StringSplitOptions.RemoveEmptyEntries);
                    double value = double.Parse(secondSplit[0], CultureInfo.InvariantCulture);
                    string status = secondSplit[1].Trim();
                    string timestamp = secondSplit[2].Trim();

                    // Add to the respective variable's records
                    if (channelMapping.ContainsKey(channelIndex))
                    {
                        int variableID = channelMapping[channelIndex];
                        var record = new ValueRecord(value, timestamp, status);
                        variables[variableID].AddRecord(record);
                    }
                }
            }

            return variables;
        }
    }
}
