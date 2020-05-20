using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Product.API.Configuration;
using System;
using System.Threading.Tasks;

namespace Product.API.Kafka
{
    public class Producer : IProducer
    {
        private readonly AppSettings appSettings;
        private const string TOPIC_DELETE_PRODUCT = "delete-product";//TODO mettre dans un service common

        public Producer(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        public async Task SendDeleteProductMessage(int productId)
        {
            ProducerConfig config = new ProducerConfig { BootstrapServers = appSettings.BrokersHosts };

            using IProducer<Null, string> producer = new ProducerBuilder<Null, string>(config).Build();
            try
            {
                DeliveryResult<Null, string> deliveryResult = await producer.ProduceAsync(TOPIC_DELETE_PRODUCT, new Message<Null, string> { Value = productId.ToString() });
                Console.WriteLine($"Delivered '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> exception)
            {
                Console.WriteLine($"Delivery failed: {exception.Error.Reason}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Delivery failed: {exception.Message}");
            }
        }
    }
}
