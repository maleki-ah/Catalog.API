using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Catalog.API.Application.Models.Paging;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure
{
    public static class DbContextServiceExtensions
    {
        public static IQueryable<TEntity> Query<TEntity>(
            this IQueryable<TEntity> query,
            string predicate
        )
        {
            if (string.IsNullOrEmpty(predicate))
            {
                return query;
            }

            return query.Where(predicate);
        }

        public static async Task<PagedList<TEntity>> Paging<TEntity>(
            this IQueryable<TEntity> query,
            PagingParam paging
        )
        {
            var totalRecords = await query.CountAsync();

            var items = await query
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .ToListAsync();

            return new PagedList<TEntity>(items, totalRecords);
        }

        public static IQueryable<TEntity> Sort<TEntity>(this IQueryable<TEntity> query, string sort)
        {
            if (string.IsNullOrEmpty(sort))
            {
                return query;
            }

            return query.OrderBy(sort);
        }
    }
}
