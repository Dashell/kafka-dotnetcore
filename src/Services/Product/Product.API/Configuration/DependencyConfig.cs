using Product.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Confluent.Kafka;
using Product.API.Kafka;

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

            #region Accessors
            #endregion

            #region Use Cases

            #endregion

            #region Repositories
            #endregion

            return services;
        }
    }
}
