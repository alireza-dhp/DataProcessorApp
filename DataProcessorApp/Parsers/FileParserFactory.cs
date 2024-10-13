namespace DataProcessorApp.Parsers
{
    public static class FileParserFactory
    {
        public static IFileParser GetParser(string fileName)
        {
            if (fileName.Trim().ToLower().EndsWith(".txt"))
                return new TextFileParser();
            //if there are any other file formats implement and call coresponding FileParser....
            //if (fileName.EndsWith(".json"))
            //    return new JsonFileParser();

            throw new NotSupportedException("File format not supported");
        }
    }
}
