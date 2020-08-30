using buildxact_supplies.FileParsing;
using buildxact_supplies.Injester;
using buildxact_supplies.ListPrinter;
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
        private readonly IListWriter _repoPrinter;

        public SupplierListService(IFileChooser fileChooser, IFileLoader fileLoader, IListWriter repoPrinter)
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
                Console.WriteLine("Files Loaded - print output to console? (y or n) ");
                
                //todo: need to handle quit input here (or other valid inputs) 
                var nextChoice = Console.ReadLine().ToLower();

                if (nextChoice == "y")
                    _repoPrinter.PrintRepo("aud");

            }


        }

    }
}
