using Microsoft.EntityFrameworkCore;
using Product.API.Infrastructure;
using Product.API.Kafka;
using Product.API.Repositories.Interfcaces;
using Product.API.UseCases.Interfcaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Models.Product>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }
    }
}
