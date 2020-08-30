using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace buildxact_supplies
{
    public class FileChoiceDto
    {
        public FileChoiceDto(int fileId, string fileName)
        {
            FileId = fileId;
            FileName = fileName;
        }
        public int FileId { get; }

        public string  FileName { get; }

    }
}
