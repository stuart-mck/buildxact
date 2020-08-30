using System.Collections.Generic;


namespace buildxact_supplies.Domain
{
    public interface IRepository<T, TPK> where T : new()
    {
        void Save(T value);

        T Load(TPK id);

        List<T> List();

    }
}
