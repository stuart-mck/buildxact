using buildxact_supplies.Domain.Supplier;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace buildxact_supplies.FileParsing
{
    public class HumphriesFileParser : IFileParser
    {
        
        public List<SupplierEntity> LoadFile(string fileName)
        {
            // this should have some validations on it - what constitutes a good record / good file structure?
            // what is the strategy for bad records? entire file fails or just that record?  need to return a list of errors or something

            var lines = File.ReadAllLines(fileName);

            return lines.Skip(1)
                 .Select(line =>
                 {
                     var lineParts = line.Split(",");

                     return new SupplierEntity
                     {
                         Currency = "aud",
                         ItemId = lineParts[0],
                         Description = lineParts[1],
                         Key = $"humphries-{lineParts[0]}",
                         Supplier = "humphries",
                         UnitPrice = decimal.Parse(lineParts[3])
                     };
                 })
                 .ToList();

        }
    }

}
