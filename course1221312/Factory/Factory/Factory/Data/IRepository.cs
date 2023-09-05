using System.Collections.Generic;

namespace Factory.Data
{
    public interface IRepository<T>
    {
        public bool Add(T itemToAdd);

        public bool Remove(int id);

        public bool Update(T itemToUpdate);

        public IEnumerable<T> GetAll();

        public int GetFreeId();

        public T Find(int id);
    }
}
