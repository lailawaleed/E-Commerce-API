using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Infrastructure.Repositories
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : BaseEntity
    {
        private readonly E_commerceContext _eCommerceContext;
        public GenericRepositories(E_commerceContext _eCommerceContext)
        {
            this._eCommerceContext = _eCommerceContext;
        }
        public T Get(int id)
        {
            return _eCommerceContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _eCommerceContext.Set<T>().ToList();
        }
        public void Add(T item)
        {
            _eCommerceContext.Set<T>().Add(item);
            _eCommerceContext.SaveChanges();
        }

        public void Delete(T item)
        {
            _eCommerceContext.Set<T>().Remove(item);
            _eCommerceContext.SaveChanges();
        }


        public void Update(T employee)
        {
            _eCommerceContext.Set<T>().Update(employee);
            _eCommerceContext.SaveChanges();
        }
    }
}
