using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Product.API.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

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

        [HttpPost]
        public NoContentResult Post(string message)
        {
            iKafkaProducer.SendMessage(message);
            return NoContent();
        }
    }
}
