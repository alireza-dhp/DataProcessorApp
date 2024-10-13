# DataProcessorApp

DataProcessorApp is a **command-line tool** that reads a data file containing historical values, processes the data to find the **minimum and maximum** values for each variable, and outputs the results to a new file.

## Features
- Parses a text file with variable and value information.
- Finds the **minimum and maximum** values for each variable along with their timestamps.
- Supports **extensibility** for different file formats (e.g., JSON) using a **Factory Pattern**.
- Built-in unit testing using **xUnit**.

## Project Structure

```plaintext
DataProcessorApp/
├── Controllers/         # Application controllers
├── Parsers/             # File parsers (e.g., TextFileParser, JsonFileParser)
├── Processors/          # Data processing logic
├── Writers/             # File output writers (e.g., TextFileWriter)
├── Models/              # Core models (e.g., Variable, ValueRecord, MinMaxRecord)
├── Program.cs           # Main entry point of the application
└── DataProcessorApp.Tests/  # Unit tests (xUnit)
```

## Cross-Platform Support

This application can run on both **Windows** and **Linux**. You can run it on Linux using the same `.NET CLI` commands.
   
