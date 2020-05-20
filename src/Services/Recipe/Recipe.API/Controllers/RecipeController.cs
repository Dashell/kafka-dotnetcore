using Microsoft.AspNetCore.Mvc;
using Recipe.API.UseCases.Interfcaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipe.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeFetcher recipeFetcher;
        public RecipeController(IRecipeFetcher recipeFetcher)
        {
            this.recipeFetcher = recipeFetcher;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Recipe>> Get()
        {
            return await recipeFetcher.Execute();
        }
    }
}
