using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Product.API.Configuration;
using Product.API.Infrastructure.Filters;
using Product.API.Infrastructure.Migrations;
using System.Reflection;

namespace Product.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));

            AppSettings appSettings = new AppSettings();
            Configuration.GetSection(nameof(AppSettings)).Bind(appSettings);


            services.AddCors();
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            });

            services.AddAutoMapper(Assembly.Load(typeof(Startup).Assembly.GetName().Name!));
            services.AddSwagger("Product.API");
            services.AddDependencies(appSettings);

            services.AddHealthChecks();
            services.AddHostedService<MigratorHostedService>();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IMapper mapper)
        {
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            app.UseDeveloperExceptionPage();
            app.UseSwaggerConfig("Product.API", "", "http");


            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc");
                endpoints.MapHealthChecks("/liveness");
            });
        }
    }
}
