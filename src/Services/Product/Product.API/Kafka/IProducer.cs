using System.Threading.Tasks;

namespace Product.API.Kafka
{
    public interface IProducer
    {
        Task SendDeleteProductMessage(int productId);
    }
}
