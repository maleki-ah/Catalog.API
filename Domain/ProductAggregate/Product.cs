using Catalog.API.Domain.Core;

namespace Catalog.API.Domain.ProductAggregate
{
    public class Product : Entity<int>
    {
        public required string Name { get; set; }
        public required int Price { get; set; }
        public string? Description { get; set; }

        //? Other Properties
    }
}
