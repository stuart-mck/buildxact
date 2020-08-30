using System.Collections.Generic;
using System.IO;

namespace buildxact_supplies.Injester
{
    public interface IFileChooser
    {
        (string command, IList<FileChoiceDto> files) ChooseFiles(DirectoryInfo targetDirectory);
    }
}
