using System.Reflection;
using Catalog.API.Domain.ProductAggregate;
using Catalog.API.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //? Maybe forgotten to apply a new config
            //modelBuilder.ApplyConfiguration(new ProductConfig());
            //modelBuilder.ApplyConfiguration(new CustomerConfig());
            //modelBuilder.ApplyConfiguration(new OtherConfig());

            //? Use this to make it dynamically apply configs
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
    }
}
