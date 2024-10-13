using DataProcessorApp.Models;
using Xunit;

namespace DataProcessorApp.Tests
{
    public class VariableTests
    {
        [Fact]
        public void GetMinMax_Returns_Correct_MinMax_With_Different_Records()
        {
            // Arrange
            var variable = new Variable(1);
            variable.AddRecord(new ValueRecord(100.000000, "12.10.2024 15:50:02.453", "40420000"));
            variable.AddRecord(new ValueRecord(150.000000, "12.10.2024 15:50:02.453", "40420000"));
            variable.AddRecord(new ValueRecord(50.000000, "12.10.2024 15:50:26.828", "40420000"));
            variable.AddRecord(new ValueRecord(200.000000, "12.10.2024 15:00:00.200", "40420000"));

            // Act
            var result = variable.GetMinMax();

            // Assert
            Assert.Equal(50, result.MinValue); // Min value is 50
            Assert.Equal("12.10.2024 15:50:26.828", result.MinTimestamp); // Timestamp for min value
            Assert.Equal(200, result.MaxValue); // Max value is 200
            Assert.Equal("12.10.2024 15:00:00.200", result.MaxTimestamp); // Timestamp for max value
        }

        [Fact]
        public void GetMinMax_Returns_MinMax_With_Same_Values_Different_Timestamps()
        {
            // Arrange
            var variable = new Variable(1);
            variable.AddRecord(new ValueRecord(100, "12.10.2024 15:50:26.828", "40420000"));
            variable.AddRecord(new ValueRecord(100, "12.10.2024 15:50:27.828", "40420000"));
            variable.AddRecord(new ValueRecord(100, "12.10.2024 15:50:28.828", "40420000"));

            // Act
            var result = variable.GetMinMax();

            // Assert
            Assert.Equal(100, result.MinValue);
            Assert.Equal("12.10.2024 15:50:26.828", result.MinTimestamp); // Earlier timestamp for min
            Assert.Equal(100, result.MaxValue);
            Assert.Equal("12.10.2024 15:50:28.828", result.MaxTimestamp); // Later timestamp for max
        }

        [Fact]
        public void GetMinMax_Returns_Same_MinMax_When_Only_One_Record()
        {
            // Arrange
            var variable = new Variable(1);
            variable.AddRecord(new ValueRecord(100, "12.10.2024 15:50:28.828", "40420000"));

            // Act
            var result = variable.GetMinMax();

            // Assert
            Assert.Equal(100, result.MinValue);
            Assert.Equal("12.10.2024 15:50:28.828", result.MinTimestamp); // Same timestamp for min and max
            Assert.Equal(100, result.MaxValue);
            Assert.Equal("12.10.2024 15:50:28.828", result.MaxTimestamp); // Same timestamp for min and max
        }
    }
}
