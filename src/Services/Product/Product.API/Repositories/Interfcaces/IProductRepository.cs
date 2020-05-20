using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repositories.Interfcaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Models.Product>> GetProducts();
    }
}
