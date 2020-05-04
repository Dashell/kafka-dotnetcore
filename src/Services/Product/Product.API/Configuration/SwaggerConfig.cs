using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace Product.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string deployedVersion)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("api", new OpenApiInfo
                {
                    Version = deployedVersion,
                    Title = $"POC Kafka {Assembly.GetEntryAssembly()!.GetName().Name}",
                    Description = $"POC Kafka {Assembly.GetEntryAssembly()!.GetName().Name}, version : {deployedVersion}"
                });

                var xmlPath = Path.ChangeExtension(Assembly.GetEntryAssembly()!.Location, "xml");
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, string deployedVersion, string routePrefix, string httpRequestScheme)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpRequestScheme}://{httpReq.Host.Value}/{routePrefix}" } };
                });

            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"./swagger/api/swagger.json", $"POC Kafka {Assembly.GetEntryAssembly()!.GetName().Name} {deployedVersion}");
                c.RoutePrefix = string.Empty;
                c.DefaultModelExpandDepth(3);
                c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.List);
                c.EnableDeepLinking();
                c.EnableFilter();
                c.ShowExtensions();
                c.EnableValidator();
            });

            return app;
        }
    }
}
