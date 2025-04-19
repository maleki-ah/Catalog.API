using Catalog.API.Domain.ProductAggregate;
using Catalog.API.Infrastructure.Core;

namespace Catalog.API.Infrastructure.Repositories
{
    // Domain Contracts
    public class ProductSqlRepository : SqlRepository<int, Product>, IProductRepository
    {
        public ProductSqlRepository(CatalogContext context)
            : base(context) { }

        //* Defer Execution
        public Task AddProductAsync(Product product) => AddAsync(product);

        public Task DeleteProductAsync(Product product) => DeleteAsync(product);

        public Task<Product?> GetProductByIdAsync(int id) => GetByIdAsync(id);

        public Task UpdateProductAsync(Product product) => UpdateAsync(product);
    }
}
