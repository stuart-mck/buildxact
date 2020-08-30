using System;

namespace buildxact_supplies.FileParsing
{
    public static class FileParserFactory
    {

        public static IFileParser GetFileParserForSupplierFile(string fileName)
        {
            if (fileName == "megacorp.json")
            {
                return new MegaCorpFileParser();
            }
            else if (fileName == "humphries.csv")
            {
                return new HumphriesFileParser();
            }
            throw new ArgumentException($"unrecognized supplier {nameof(fileName)}");
        }
    }
}
