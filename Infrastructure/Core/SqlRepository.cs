using Catalog.API.Application.Contracts;
using Catalog.API.Domain.Contracts;
using Catalog.API.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Core
{
    //? Application Contracts + SQL Server
    public abstract class SqlRepository<Key, T> : IRepository<Key, T>
        where T : Entity<Key>
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _set;

        protected SqlRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _set.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
