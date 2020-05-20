using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Product.API.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
              : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Product>()
                .HasData(new List<Models.Product> {
                new Models.Product
                {
                    Name = "Poulet",
                    Id = 1
                },
                new Models.Product
                {
                    Name = "Curry",
                    Id = 2
                },
                new Models.Product
                {
                    Name = "Tandori",
                    Id = 3
                },
                new Models.Product
                {
                    Name = "Bo",
                    Id = 4
                },
                new Models.Product
                {
                   Name = "Boun",
                    Id = 5
                },
                new Models.Product
                {
                    Name = "Pokeball",
                    Id = 6
                },
                new Models.Product
                {
                    Name = "Pokeball",
                    Id = 7
                },
                new Models.Product
                {
                    Name = "Milk",
                    Id = 8 
                },
                new Models.Product
                {
                    Name = "Bacon",
                    Id = 9
                }
            });
        }

        public DbSet<Models.Product> Products { get; set; }

    }
}
