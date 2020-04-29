using Microsoft.EntityFrameworkCore;

namespace Recipe.API.Infrastructure
{
    public class RecipeContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public RecipeContext(DbContextOptions<RecipeContext> options)
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
              : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.RecipeProduct>()
             .HasKey(rp => new { rp.RecipeId, rp.ProductId });
            modelBuilder.Entity<Models.RecipeProduct>()
                .HasOne(rp => rp.Recipe)
                .WithMany(r => r.Products)
                .HasForeignKey(rp => rp.RecipeId);
        }
        public DbSet<Models.Recipe> Recipes { get; set; }

    }
}
