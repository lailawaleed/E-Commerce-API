using E_Commerce.Domain.Entities;

namespace E_Commerce.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepositories<T> Repository<T>() where T : BaseEntity;
        int Complete();
    }
}
