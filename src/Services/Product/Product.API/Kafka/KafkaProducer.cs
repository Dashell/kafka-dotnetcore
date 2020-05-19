﻿using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Product.API.Configuration;

namespace Product.API.Kafka
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly AppSettings appSettings;

        public KafkaProducer(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        public async Task SendMessage(string message)
        {
            var config = new ProducerConfig { BootstrapServers = "kafka1:29092,kafka2:29093,kafka3:29094" };

            using var p = new ProducerBuilder<Null, string>(config).Build();
            try
            {
                var dr = await p.ProduceAsync("delete-product", new Message<Null, string> { Value = message });
                Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Delivery failed: {e.Message}");
            }
        }
    }
}
