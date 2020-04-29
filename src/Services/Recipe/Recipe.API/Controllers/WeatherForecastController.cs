using Microsoft.AspNetCore.Mvc;

namespace Recipe.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        public RecipeController()
        {
        }

        [HttpGet]
        public NoContentResult Get()
        {
            return NoContent();
        }
    }
}
