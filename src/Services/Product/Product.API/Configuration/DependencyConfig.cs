using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.API.Infrastructure;
using Product.API.Kafka;
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
            services.AddTransient<IKafkaProducer, KafkaProducer>();
            #endregion

            #region Use Cases
            services.AddTransient<IProductRemover, ProductRemover>();

            #endregion

            #region Repositories
            #endregion

            return services;
        }
    }
}
