using DataProcessorApp.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataProcessorApp.Tests
{
    public class TextFileParserTests
    {
        [Fact]
        public void ParseFile_Correctly_Parses_File_With_Multiple_Records()
        {
            // Arrange
            var testData = @"-HEADER-
Name :A1
Start:06.03.2007 15:50:00.000
End  :01.01.1970 01:00:00.000
-VARIABLES-
@0=5
@1=6
@2=7
-VALUES-
@0:50.000000;40420000;13.10.2024 08:00:00
@1:100.000000;40420000;13.10.2024 09:00:00
@2:150.000000;40420000;13.10.2024 10:00:00
@0:75.000000;40420000;13.10.2024 11:00:00
";

            var fileName = "testfile.txt";
            File.WriteAllText(fileName, testData); // Create a temporary test file
            var parser = new TextFileParser();

            // Act
            var result = parser.ParseFile(fileName);

            // Assert
            Assert.Equal(3, result.Count); // Ensure we have 3 variables parsed

            // Validate variable 5
            var variable1 = result[5];
            Assert.Equal(2, variable1.Records.Count); // Two records for variable 5
            Assert.Equal(50, variable1.Records[0].Value); // First record value
            Assert.Equal(75, variable1.Records[1].Value); // Second record value

            // Validate variable 6
            var variable2 = result[6];
            Assert.Single(variable2.Records); // One record for variable 6
            Assert.Equal(100, variable2.Records[0].Value);

            // Validate variable 7
            var variable3 = result[7];
            Assert.Single(variable3.Records); // One record for variable 7
            Assert.Equal(150, variable3.Records[0].Value);
        }
    }
}
