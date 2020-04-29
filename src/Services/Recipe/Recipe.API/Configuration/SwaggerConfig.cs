using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace Recipe.API.Configuration
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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = $"JWT Authorization header using the Bearer scheme.{Environment.NewLine}{Environment.NewLine}Enter 'Bearer' [space] and then your token in the text input below.{Environment.NewLine}{Environment.NewLine}Example: \"Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6InhRbHU5R2g0alMxQ1c3RWc5RTdaaEEiLCJ0....\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
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
