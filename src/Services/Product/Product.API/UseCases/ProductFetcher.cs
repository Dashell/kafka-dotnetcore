using Product.API.Kafka;
using Product.API.Repositories.Interfcaces;
using Product.API.UseCases.Interfcaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.UseCases
{
    public class ProductFetcher : IProductFetcher
    {
        private readonly IProductRepository iProductRepository;
        public ProductFetcher(IProductRepository iProductRepository)
        {
            this.iProductRepository = iProductRepository;
        }

        public async Task<IEnumerable<Models.Product>> Execute()
        {
            return await iProductRepository.GetProducts();
        }
    }
}
