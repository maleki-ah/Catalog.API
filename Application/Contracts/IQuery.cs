using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Catalog.API.Application.Models;
using Catalog.API.Application.Models.Paging;

namespace Catalog.API.Application.Contracts
{
    public interface IQuery<TEntity>
    {
        //? Expression Tree
        //? Specification Pattern
        public Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<PagedList<TEntity>> FilterAsync(string predicate, QueryData data);
        public Task<PagedList<TEntity>> SearchAsync(string searchText, QueryData data);
    }
}
