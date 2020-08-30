using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace buildxact_supplies
{
    public interface IFileParser
    {
        List<SupplierEntity> LoadFile(string fileName);

    }



    public class MegaCorpFileParser : IFileParser
    {

        public List<SupplierEntity> LoadFile(string fileName)
        {
            return new List<SupplierEntity>();
        }
        
    }


    public class HumphriesFileParser : IFileParser
    {
        public List<SupplierEntity> LoadFile(string fileName)
        {
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
