namespace Catalog.API.Domain.ProductAggregate
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);

        //? Domain Constraint
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
    }
}
