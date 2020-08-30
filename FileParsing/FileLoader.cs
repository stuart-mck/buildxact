using buildxact_supplies.Domain;
using buildxact_supplies.Domain.Supplier;
using System.Collections.Generic;
using System.IO;


namespace buildxact_supplies.FileParsing
{
    public class FileLoader : IFileLoader
    {
        private readonly IRepository<SupplierEntity, string> _repository;

        public FileLoader(IRepository<SupplierEntity, string> repository)
        {
            _repository = repository;
        }

        public List<string> LoadFiles(DirectoryInfo targetDirectory, IList<FileChoiceDto> filesToLoad)
        {
            var results = new List<string>();
            foreach (var file in filesToLoad)
            {
                var completeFilePath = Path.Combine(targetDirectory.FullName, file.FileName);
                if (File.Exists(completeFilePath))
                {
                    var fileParser = FileParserFactory.GetFileParserForSupplierFile(file.FileName);

                    fileParser.LoadFile(completeFilePath)
                        .ForEach(entity => _repository.Save(entity));

                }
                else
                {
                    results.Add($"{file.FileName} not found in {targetDirectory.FullName}");
                }
            }
            return results;
        }
    }
}
