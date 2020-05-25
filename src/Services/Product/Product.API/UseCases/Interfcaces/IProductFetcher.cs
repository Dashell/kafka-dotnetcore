using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.UseCases.Interfcaces
{
    public interface IProductFetcher
    {
        Task<IEnumerable<Models.Product>> Execute();
    }
}
