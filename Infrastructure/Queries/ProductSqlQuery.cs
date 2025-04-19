using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Catalog.API.Application.Contracts;
using Catalog.API.Application.Contracts.Query;
using Catalog.API.Application.Models;
using Catalog.API.Application.Models.Paging;
using Catalog.API.Domain.ProductAggregate;
using Catalog.API.Infrastructure;
using Catalog.API.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Queries
{
    public class ProductSqlQuery : SqlQuery<Product>, IProductQuery
    {
        public ProductSqlQuery(CatalogContext context)
            : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByMinPriceAsync(int minPrice)
        {
            return await FilterAsync(p => p.Price >= minPrice);
        }

        public async Task<PagedList<Product>> FilterProductsAsync(string predicate, QueryData data)
        {
            return await FilterAsync(predicate, data);
        }

        //? Specific Public Search
        public async Task<PagedList<Product>> SearchProductsAsync(string searchText, QueryData data)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return await _set.AsNoTracking().Sort(data.Sort).Paging(data.Paging);
            }

            return await _set.AsNoTracking()
                .Where(product =>
                    EF.Functions.Like(product.Name, $"%{searchText}%")
                    || EF.Functions.Like(product.Description, $"%{searchText}%")
                    || EF.Functions.Like(product.Price.ToString(), $"%{searchText}%")
                )
                .Sort(data.Sort)
                .Paging(data.Paging);
        }
    }
}
