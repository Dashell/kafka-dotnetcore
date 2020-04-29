using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }

        [HttpPost]
        public NoContentResult Post(string message)
        {
            return NoContent();
        }
    }
}
