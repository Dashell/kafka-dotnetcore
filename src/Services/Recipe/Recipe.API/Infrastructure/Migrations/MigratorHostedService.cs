using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Recipe.API.Infrastructure.Migrations
{
    public class MigratorHostedService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        public MigratorHostedService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
                using IServiceScope scope = serviceProvider.CreateScope();
                RecipeContext repiceContext = scope.ServiceProvider.GetRequiredService<RecipeContext>();

                await repiceContext.Database.MigrateAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
