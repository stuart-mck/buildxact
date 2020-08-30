using System.Collections.Generic;
using System.IO;


namespace buildxact_supplies.FileParsing
{
    public interface IFileLoader
    {
        List<string> LoadFiles(DirectoryInfo targetDirectory, IList<FileChoiceDto> filesToLoad);
    }
}
