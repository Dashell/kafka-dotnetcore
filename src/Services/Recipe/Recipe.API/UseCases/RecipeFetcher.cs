using Recipe.API.Repositories.Interfcaces;
using Recipe.API.UseCases.Interfcaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.API.UseCases
{
    public class RecipeFetcher : IRecipeFetcher
    {
        private readonly IRecipeRepository recipeRepository;
        public RecipeFetcher(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public async Task<IEnumerable<Models.Recipe>> Execute()
        {
            return await recipeRepository.GetAll();
        }
    }
}
