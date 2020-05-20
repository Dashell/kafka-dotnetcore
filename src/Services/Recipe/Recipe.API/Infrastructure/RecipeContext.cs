using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Recipe.API.Infrastructure
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
              : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Recipe>().HasData(new List<Models.Recipe> { 
                new Models.Recipe 
                {
                    Id = 0, 
                    Name = "Poulet Curry"
                },
                new Models.Recipe
                {
                    Id = 1,
                    Name = "Poulet Tandory"
                },
                new Models.Recipe
                {
                    Id = 2,
                    Name = "Bo Boun"
                },
                new Models.Recipe
                {
                    Id = 3,
                    Name = "PokeBall Oignon free"
                },
                new Models.Recipe
                {
                    Id = 4,
                    Name = "MilkShake Bacon"
                }
            });

            modelBuilder.Entity<Models.RecipeProduct>()
             .HasKey(rp => new { rp.RecipeId, rp.ProductId });
            modelBuilder.Entity<Models.RecipeProduct>()
                .HasOne(rp => rp.Recipe)
                .WithMany(r => r.Products)
                .HasForeignKey(rp => rp.RecipeId);

            modelBuilder.Entity<Models.RecipeProduct>()
                .HasData(new List<Models.RecipeProduct> {
                new Models.RecipeProduct
                {
                    RecipeId = 0,
                    ProductId = 1 //Poulet
                },
                new Models.RecipeProduct
                {
                    RecipeId = 0,
                    ProductId = 2 //Curry
                },
                new Models.RecipeProduct
                {
                    RecipeId = 1,
                    ProductId = 1 //Poulet
                },
                new Models.RecipeProduct
                {
                    RecipeId = 1,
                    ProductId = 3 //Tandori
                },
                new Models.RecipeProduct
                {
                    RecipeId = 2,
                    ProductId = 4 // Bo
                },
                new Models.RecipeProduct
                {
                    RecipeId = 2,
                    ProductId = 5 // Boun
                },
                new Models.RecipeProduct
                {
                    RecipeId = 3,
                    ProductId = 6 // Pokeball
                },
                new Models.RecipeProduct
                {
                    RecipeId = 3,
                    ProductId = 7 // Pokeball
                },
                new Models.RecipeProduct
                {
                    RecipeId = 4,
                    ProductId = 8 // Milk
                },

                new Models.RecipeProduct
                {
                    RecipeId = 4,
                    ProductId = 9 // Bacon
                }
            });
        }
        public DbSet<Models.Recipe> Recipes { get; set; }

    }
}
