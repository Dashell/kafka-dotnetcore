using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recipe.API.Infrastructure;
using Recipe.API.Repositories;
using Recipe.API.Repositories.Interfcaces;
using Recipe.API.UseCases;
using Recipe.API.UseCases.Interfcaces;

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
            services.AddTransient<IRecipeRemover, RecipeRemover>();
            services.AddTransient<IRecipeFetcher, RecipeFetcher>();

            #endregion

            #region Repositories
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            #endregion

            return services;
        }
    }
}
