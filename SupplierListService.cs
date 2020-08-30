using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace buildxact_supplies
{
    public class SupplierListService
    {
        private readonly IFileChooser _fileChooser;
        private readonly IFileLoader _fileLoader;
        private readonly IRepoPrinter _repoPrinter;

        public SupplierListService(IFileChooser fileChooser, IFileLoader fileLoader, IRepoPrinter repoPrinter)
        {
            _fileChooser = fileChooser;
            _fileLoader = fileLoader;
            _repoPrinter = repoPrinter;
        }

        public void ProcessFiles(DirectoryInfo targetDirectory)
        {
            (string choice, IList<FileChoiceDto> filesToLoad) = _fileChooser.ChooseFiles(targetDirectory);

            if (choice == "q")
                return;

            if (choice == "d")
            {
                var results = _fileLoader.LoadFiles(targetDirectory, filesToLoad);
                Console.Write("Files Loaded - print output to console?");

                var nextChoice = Console.ReadLine().ToLower();

                if (nextChoice == "y")
                    _repoPrinter.PrintRepo("aud");

            }


        }

    }
}
