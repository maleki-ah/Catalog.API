using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Catalog.API.Application.Contracts;
using Catalog.API.Application.Models;
using Catalog.API.Application.Models.Paging;
using Catalog.API.Domain.Contracts;
using Catalog.API.Domain.Core;
using Catalog.API.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Core
{
    //? Application Contracts + SQL Server
    public abstract class SqlQuery<TEntity> : IQuery<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> _set;

        protected SqlQuery(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> FilterAsync(
            Expression<Func<TEntity, bool>> predicate
        )
        {
            return await _set.Where(predicate).ToListAsync();
        }

        public Task<PagedList<TEntity>> FilterAsync(string predicate, QueryData data)
        {
            return _set.AsNoTracking().Query(predicate).Sort(data.Sort).Paging(data.Paging);
        }

        public virtual Task<PagedList<TEntity>> SearchAsync(string searchText, QueryData data)
        {
            throw new NotImplementedException();
        }
    }
}
