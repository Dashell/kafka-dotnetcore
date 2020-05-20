using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Recipe.API.Configuration;
using Recipe.API.UseCases.Interfcaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Recipe.API.Kafka
{
    public class Consumer : IHostedService
    {
        private readonly AppSettings appSettings;
        private readonly IProductRemover productRemover;
        private const string TOPIC_DELETE_PRODUCT = "delete-product";//TODO mettre dans un service common

        public Consumer(IOptions<AppSettings> appSettings, IProductRemover productRemover)
        {
            this.appSettings = appSettings.Value;
            this.productRemover = productRemover;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            ConsumerConfig config = new ConsumerConfig
            {
                GroupId = appSettings.ConsumerGroup,
                BootstrapServers = appSettings.BrokersHosts,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config)
                // Note: All handlers are called on the main .Consume thread.
                .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                .SetStatisticsHandler((_, json) => Console.WriteLine($"Statistics: {json}"))
                .SetPartitionsAssignedHandler((c, partitions) =>
                {
                    Console.WriteLine($"Assigned partitions: [{string.Join(", ", partitions)}]");
                    // possibly manually specify start offsets or override the partition assignment provided by
                    // the consumer group by returning a list of topic/partition/offsets to assign to, e.g.:
                    // 
                    // return partitions.Select(tp => new TopicPartitionOffset(tp, externalOffsets[tp]));
                })
                .SetPartitionsRevokedHandler((c, partitions) =>
                {
                    Console.WriteLine($"Revoking assignment: [{string.Join(", ", partitions)}]");
                })
                .Build();

            consumer.Subscribe(TOPIC_DELETE_PRODUCT);

            const int commitPeriod = 5;
            try
            {
                while (true)
                {
                    try
                    {
                        var consumeResult = consumer.Consume(cancellationToken);

                        if (consumeResult.IsPartitionEOF)
                        {
                            Console.WriteLine(
                                $"Reached end of topic {consumeResult.Topic}, partition {consumeResult.Partition}, offset {consumeResult.Offset}.");

                            continue;
                        }

                        Console.WriteLine($"Received message at {consumeResult.TopicPartitionOffset}: {consumeResult.Message.Value}, with group : {appSettings.ConsumerGroup}");
                        
                        if(int.TryParse(consumeResult.Message.Value, out int productId))
                        {
                            await productRemover.Execute(productId);
                        }
                        else
                        {
                            throw new ArgumentException("message value is not an int");
                        }


                        if (consumeResult.Offset % commitPeriod == 0)
                        {
                            // The Commit method sends a "commit offsets" request to the Kafka
                            // cluster and synchronously waits for the response. This is very
                            // slow compared to the rate at which the consumer is capable of
                            // consuming messages. A high performance application will typically
                            // commit offsets relatively infrequently and be designed handle
                            // duplicate messages in the event of failure.
                            try
                            {
                                consumer.Commit(consumeResult);
                            }
                            catch (KafkaException e)
                            {
                                Console.WriteLine($"Commit error: {e.Error.Reason}");
                            }
                        }
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Consume error: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Closing consumer.");
                consumer.Close();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
