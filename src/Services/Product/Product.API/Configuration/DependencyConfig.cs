using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.API.Infrastructure;
using Product.API.Kafka;
using Product.API.Repositories;
using Product.API.Repositories.Interfcaces;
using Product.API.UseCases;
using Product.API.UseCases.Interfcaces;

namespace Product.API.Configuration
{
    public static class DependencyConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            #region Database
            services.AddDbContext<ProductContext>(options => options.UseLazyLoadingProxies().UseNpgsql(appSettings.DbConnection).UseSnakeCaseNamingConvention());
            #endregion

            #region Kafka Producer
            services.AddTransient<IProducer, Producer>();
            #endregion

            #region Use Cases
            services.AddTransient<IProductRemover, ProductRemover>();
            services.AddTransient<IProductFetcher, ProductFetcher>();

            #endregion

            #region Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion

            return services;
        }
    }
}
