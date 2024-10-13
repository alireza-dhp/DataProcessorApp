using DataProcessorApp.Parsers;
using DataProcessorApp.Processors;
using DataProcessorApp.Writers;

namespace DataProcessorApp.Controllers
{
    public class AppController
    {
        private readonly IFileParser _parser;
        private readonly IProcessor _processor;
        private readonly IFileWriter _writer;

        public AppController(IFileParser parser, IProcessor processor, IFileWriter writer)
        {
            _parser = parser;
            _processor = processor;
            _writer = writer;
        }

        public void Run(string inputFileName, string outputFileName)
        {
            var variables = _parser.ParseFile(inputFileName);
            var results = _processor.Process(variables);
            _writer.WriteResults(results, outputFileName);
        }
    }
}