using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//https://stackoverflow.com/questions/3527203/getfiles-with-multiple-extensions

namespace buildxact_supplies
{
    public static class FileListerExtensions
    {
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions)
        {
            if (extensions == null)
                throw new ArgumentNullException("extensions");
            IEnumerable<FileInfo> files = Enumerable.Empty<FileInfo>();
            foreach (string ext in extensions)
            {
                files = files.Concat(dir.GetFiles(ext));
            }
            return files;
        }
    }
}
