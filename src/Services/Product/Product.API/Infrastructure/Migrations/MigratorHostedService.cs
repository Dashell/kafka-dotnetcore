using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Product.API.Infrastructure.Migrations
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
            ProductContext productContext = scope.ServiceProvider.GetRequiredService<ProductContext>();

            await productContext.Database.MigrateAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
