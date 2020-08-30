using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace buildxact_supplies
{
    public interface IFileChooser
    {
        (string command, IList<FileChoiceDto> files) ChooseFiles(DirectoryInfo targetDirectory);
    }

    public class FileChooser : IFileChooser
    {
        private static List<string> ValidCommands = new List<string>(){
                "q",
                "d"
            };

        public  (string command, IList<FileChoiceDto> files) ChooseFiles(DirectoryInfo targetDirectory)
        {
            List<FileChoiceDto> filesToInDirectory = GetDirectoryFileList(targetDirectory);

            var filesToLoad = new List<FileChoiceDto>();
            var userChoice = string.Empty;

            while (ValidCommands.All(cmd => cmd != userChoice))
            {
                userChoice = string.Empty;

                ShowChosenFiles(filesToLoad);

                var filesToChooseFrom = filesToInDirectory
                    .Where(t => filesToLoad.All(ftl => ftl.FileName != t.FileName))
                    .Select(f => new FileChoiceDto(f.FileId, f.FileName))
                    .ToList();

                if (filesToChooseFrom.Any())
                {
                    Console.WriteLine("Available Files");
                    filesToChooseFrom.ForEach(fdt => Console.WriteLine($"{fdt.FileId} - {fdt.FileName}"));
                    Console.WriteLine("Enter file number to select, d for done or q for quit");

                }

                userChoice = Console.ReadLine().ToLower();

                // numeric input?
                if (int.TryParse(userChoice, out var chosenFileId))
                {
                    // valid choice?
                    if (filesToInDirectory.Any(f => f.FileId == chosenFileId))
                    {
                        //remove or insert choice into list
                        var choiceExists = filesToLoad.FirstOrDefault(t => t.FileId == chosenFileId);
                        if (choiceExists == null)
                        {
                            filesToLoad.Add(filesToChooseFrom.First(t => t.FileId == chosenFileId));
                        }
                        else
                        {
                            filesToLoad.Remove(choiceExists);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid entry - choose one of {string.Join(",", filesToChooseFrom.Select(t => t.FileId))} or one of {string.Join(",", ValidCommands)}");
                        continue;
                    }
                }
                else
                {
                    if (ValidCommands.All(c => c != userChoice))
                    {
                        Console.WriteLine($"Invalid entry - choose one of {string.Join(",", filesToChooseFrom.Select(t => t.FileId))} or one of {string.Join(",", ValidCommands)}");
                        continue;
                    }
                }
            }

            return (userChoice, filesToLoad);
        }


        private static void ShowChosenFiles(List<FileChoiceDto> filesToLoad)
        {
            if (filesToLoad.Any())
            {
                Console.WriteLine("Selected Files");
                filesToLoad.ForEach(ftl => Console.WriteLine($"{ftl.FileId} - {ftl.FileName}"));
                Console.WriteLine("Enter file number to deselect");
                Console.WriteLine();
            }
        }

        private static List<FileChoiceDto> GetDirectoryFileList(DirectoryInfo targetDirectory)
        {
            return targetDirectory.GetFilesByExtensions(new[] { "*.csv", "*.json" })
               .Select((x, i) => new FileChoiceDto(i, x.Name))
               .ToList();
        }
    }
}
