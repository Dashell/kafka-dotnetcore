using Product.API.Kafka;
using Product.API.UseCases.Interfcaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.UseCases
{
    public class ProductRemover : IProductRemover
    {
        private readonly IKafkaProducer iKafkaProducer;
        public ProductRemover(IKafkaProducer iKafkaProducer)
        {
            this.iKafkaProducer = iKafkaProducer;
        }
        public async Task Execute(int productId)
        {
            //TODO => Call repository to remove product in database

            await iKafkaProducer.SendDeleteProductMessage(productId);
        }
    }
}
