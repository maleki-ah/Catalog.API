using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Application.Models;
using Catalog.API.Application.Models.Paging;
using Catalog.API.Domain.ProductAggregate;

namespace Catalog.API.Application.Contracts.Query
{
    public interface IProductQuery
    {
        public Task<IEnumerable<Product>> GetProductsByMinPriceAsync(int minPrice);
        public Task<PagedList<Product>> FilterProductsAsync(string predicate, QueryData data);
        public Task<PagedList<Product>> SearchProductsAsync(string searchText, QueryData data);
    }
}
