using Microsoft.AspNetCore.Mvc;
using Product.API.Kafka;
using Product.API.UseCases.Interfcaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductFetcher productFetcher;
        private readonly IProductRemover productRemover;
        public ProductController(IProductFetcher productFetcher, IProductRemover productRemover)
        {
            this.productFetcher = productFetcher;
            this.productRemover = productRemover;
        }

        [HttpDelete("{productId}")]
        public async Task<NoContentResult> Delete(int productId)
        {
            await productRemover.Execute(productId);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Product>> Get()
        {
            return await productFetcher.Execute();
        }
    }
}
