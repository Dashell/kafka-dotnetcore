using Microsoft.EntityFrameworkCore;

namespace Product.API.Infrastructure
{
    public class ProductContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public ProductContext(DbContextOptions<ProductContext> options)
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
              : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Models.Product> Products { get; set; }

    }
}
