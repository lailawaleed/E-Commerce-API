using E_Commerce.Domain.Entities;

namespace E_Commerce.Domain.Contracts
{
    public interface IGenericRepositories<T> where T : BaseEntity
    {
        public T Get(int id);
        public IEnumerable<T> GetAll();
        public void Update(T item);
        public void Delete(T item);
        public void Add(T item);
    }
}
