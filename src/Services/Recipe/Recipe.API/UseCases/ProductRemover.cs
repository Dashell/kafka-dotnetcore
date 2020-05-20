using Recipe.API.Kafka;
using Recipe.API.Repositories.Interfcaces;
using Recipe.API.UseCases.Interfcaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.API.UseCases
{
    public class ProductRemover : IProductRemover
    {
        private readonly IRecipeRepository iRecipeRepository;
        public ProductRemover(IRecipeRepository iRecipeRepository)
        {
            this.iRecipeRepository = iRecipeRepository;
        }
        public async Task Execute(int productId)
        {
            await iRecipeRepository.RemoveRecipeWithProduct(productId);
        }
    }
}
