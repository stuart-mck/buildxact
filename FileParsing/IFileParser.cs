using buildxact_supplies.Domain.Supplier;
using System.Collections.Generic;

namespace buildxact_supplies.FileParsing
{
    public interface IFileParser
    {
        List<SupplierEntity> LoadFile(string fileName);

    }

}
