namespace DataProcessorApp.Models
{
    public record ValueRecord(double Value, string Timestamp, string Status);
    public record MinMaxRecord(double MinValue, string MinTimestamp, double MaxValue, string MaxTimestamp);
    public class Variable
    {
        public int VariableID { get; }
        public List<ValueRecord> Records { get; }

        public Variable(int variableID)
        {
            VariableID = variableID;
            Records = new List<ValueRecord>();
        }

        public void AddRecord(ValueRecord record)
        {
            Records.Add(record);
        }

        public MinMaxRecord GetMinMax()
        {
            double minValue = double.MaxValue;
            string minTimestamp = string.Empty;
            double maxValue = double.MinValue;
            string maxTimestamp = string.Empty;

            foreach (var record in Records)
            {
                // Update min value and timestamp
                if (record.Value < minValue)
                {
                    minValue = record.Value;
                    minTimestamp = record.Timestamp;
                }
                else if (record.Value == minValue) // Same min value, compare timestamps
                {
                    // Keep the record with the earlier (minimum) timestamp
                    if (DateTime.Parse(record.Timestamp) < DateTime.Parse(minTimestamp))
                    {
                        minTimestamp = record.Timestamp;
                    }
                }

                // Update max value and timestamp
                if (record.Value > maxValue)
                {
                    maxValue = record.Value;
                    maxTimestamp = record.Timestamp;
                }
                else if (record.Value == maxValue) // Same max value, compare timestamps
                {
                    // Keep the record with the later (maximum) timestamp
                    if (DateTime.Parse(record.Timestamp) > DateTime.Parse(maxTimestamp))
                    {
                        maxTimestamp = record.Timestamp;
                    }
                }
            }

            return new MinMaxRecord(minValue, minTimestamp, maxValue, maxTimestamp);
        }
    }
}
