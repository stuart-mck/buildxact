using System.Collections.Generic;


namespace buildxact_supplies
{
    public interface IRepository<T, TPK> where T : new()
    {
        void Save (T value);

        T Load(TPK id);

        List<T> List();

    }

    public class SupplierRepository : IRepository<SupplierEntity, string>
    {
        private readonly List<SupplierEntity> _memoryStore = new List<SupplierEntity>();

        public void Save(SupplierEntity value)
        {
            _memoryStore.Add(value);
        }

        public SupplierEntity Load(string id)
        {
            return new SupplierEntity();
        }

        public List<SupplierEntity> List()
        {
            return _memoryStore;
        }


    }
}
