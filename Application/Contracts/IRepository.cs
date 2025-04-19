using Catalog.API.Domain.Contracts;

namespace Catalog.API.Application.Contracts
{
    public interface IRepository<Key, T> where T : IEntity<Key>
    {
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
