using Microsoft.AspNetCore.Mvc;

namespace Recipe.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class RecipeController : ControllerBase
    {
        public RecipeController()
        {
        }

        [HttpGet]
        public string Test()
        {
            return "Ok";
        }
    }
}
