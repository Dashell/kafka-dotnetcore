using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recipe.API.Infrastructure;

namespace Recipe.API.Configuration
{
    public static class DependencyConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            #region Database
            services.AddDbContext<RecipeContext>(options => options.UseLazyLoadingProxies().UseNpgsql(appSettings.DbConnection).UseSnakeCaseNamingConvention());
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
