using Catalog.API.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.Config
{
    //? Metadata (SQL Server)
    //? Fluent API Model
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo("ProductSeq");
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(100);
        }
    }
}
