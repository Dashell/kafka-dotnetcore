using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Kafka
{
    public interface IKafkaProducer
    {
        Task SendMessage();
    }
}
