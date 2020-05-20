using Microsoft.AspNetCore.Mvc;
using Product.API.Kafka;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IKafkaProducer iKafkaProducer;
        public ProductController(IKafkaProducer iKafkaProducer)
        {
            this.iKafkaProducer = iKafkaProducer;
        }

        [HttpDelete("{productId}")]
        public NoContentResult Delete(int productId)
        {
            //TODO => Call UseCase For Remove Product in Database

            iKafkaProducer.SendMessage(productId);

            return NoContent();
        }
    }
}
