using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Repositories;
using System.Collections;

namespace E_Commerce.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly E_commerceContext _eCommerceContext;
        public Hashtable _repositories { get; set; }
        public UnitOfWork(E_commerceContext e_CommerceContext)
        {
            _eCommerceContext = e_CommerceContext;
            _repositories = new Hashtable();
        }

        public IGenericRepositories<T> Repository<T>() where T : BaseEntity
        {
            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                _repositories.Add(type, new GenericRepositories<T>(_eCommerceContext));
            }
            return (IGenericRepositories<T>)_repositories[type];
        }
        public int Complete()
        {
            //Return number of affected rows
            return _eCommerceContext.SaveChanges();
        }
        public void Dispose()
        {
            _eCommerceContext.Dispose();
        }
    }
}
