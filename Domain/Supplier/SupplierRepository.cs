using System;
using System.Collections.Generic;


namespace buildxact_supplies.Domain.Supplier
{
    public class SupplierRepository : IRepository<SupplierEntity, string>
    {
        private readonly List<SupplierEntity> _memoryStore = new List<SupplierEntity>();

        public void Save(SupplierEntity value)
        {
            _memoryStore.Add(value);
        }

        public SupplierEntity Load(string id)
        {
            throw new NotImplementedException();
        }

        public List<SupplierEntity> List()
        {
            return _memoryStore;
        }


    }
}
