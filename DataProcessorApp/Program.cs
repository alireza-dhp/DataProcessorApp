using DataProcessorApp.Controllers;
using DataProcessorApp.Parsers;
using DataProcessorApp.Processors;
using DataProcessorApp.Writers;

namespace DataProcessorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: DataProcessorApp <inputFileName> <outputFileName>");
                return;
            }

            string inputFileName = args[0];
            string outputFileName = args[1];

            if (!File.Exists(inputFileName))
            {
                FileInfo f = new(inputFileName);
                Console.WriteLine($"File {f.FullName} did not find!");
                return;
            }

            IFileParser parser = FileParserFactory.GetParser(inputFileName);
            IProcessor processor = new ValueProcessor();
            IFileWriter writer = new TextFileWriter();

            AppController app = new(parser, processor, writer);
            app.Run(inputFileName, outputFileName);

            if (File.Exists(outputFileName))
            {
                FileInfo f = new(outputFileName);
                Console.WriteLine($"Output file {f.FullName}");
                return;
            }
        }
    }  


}