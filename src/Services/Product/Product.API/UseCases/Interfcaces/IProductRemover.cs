using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.UseCases.Interfcaces
{
    public interface IProductRemover
    {
        Task Execute(int productId);
    }
}
