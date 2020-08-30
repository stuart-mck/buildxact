using buildxact_supplies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SuppliesPriceLister
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetDirectory = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Imports"));

            var filesToInDirectory = targetDirectory.GetFilesByExtensions(new[] {"*.csv", "*.json" });

            var filesToLoad = new List<FileChoiceDto>();
            var userChoice = string.Empty;

            var validCommands = new List<string>()
            {
                "q",
                "d"
            };

            while (userChoice != "d")
            {
                userChoice = string.Empty;

                var currentFileSet = filesToInDirectory
                    .Where(t => filesToLoad.All(ftl => ftl.FileName != t.Name))
                    .Select((x, i) => new FileChoiceDto(i, x.Name))
                    .ToList();

                currentFileSet.ForEach(fdt => Console.WriteLine($"{fdt.FileId} - {fdt.FileName}"));

                userChoice = Console.ReadLine().ToLower();

                

                    // numeric input?
                if (int.TryParse(userChoice,  out var chosenFileId))
                {
                    // valid choice?
                    if (currentFileSet.Any(f => f.FileId != chosenFileId))
                    {
                        //remove or insert choice into list
                        var choiceExists = filesToLoad.FirstOrDefault(t => t.FileId == chosenFileId);
                        if (choiceExists == null )
                        {
                            filesToLoad.Add(choiceExists);
                        }
                        else
                        {
                            filesToLoad.Remove(choiceExists);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid entry - choose one of {string.Join(",", currentFileSet.Select(t => t.FileId))} or one of {string.Join(",", validCommands)}");
                        continue;
                    }
                }
                else
                {
                    if (validCommands.All(c => c != userChoice))
                    {
                        Console.WriteLine($"Invalid entry - choose one of {string.Join(",", currentFileSet.Select(t => t.FileId))} or one of {string.Join(",", validCommands)}");
                        continue;
                    }
                }
            }

        }
    }
}
