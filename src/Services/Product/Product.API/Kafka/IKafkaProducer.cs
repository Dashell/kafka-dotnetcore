using System.Threading.Tasks;

namespace Product.API.Kafka
{
    public interface IKafkaProducer
    {
        Task SendDeleteProductMessage(int productId);
    }
}
