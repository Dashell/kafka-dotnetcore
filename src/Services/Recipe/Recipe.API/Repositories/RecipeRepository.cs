using Recipe.API.Infrastructure;
using Recipe.API.Kafka;
using Recipe.API.Repositories.Interfcaces;
using Recipe.API.UseCases.Interfcaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.API.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeContext context;

        public RecipeRepository(RecipeContext context)
        {
            this.context = context;
        }

        public async Task RemoveRecipeWithProduct(int productId)
        {
            IEnumerable<Models.Recipe> recipes = context.Recipes.Where(recipe => recipe.Products.Any(product => product.ProductId == productId));

            context.RemoveRange(recipes);

            await context.SaveChangesAsync();
        }
    }
}
