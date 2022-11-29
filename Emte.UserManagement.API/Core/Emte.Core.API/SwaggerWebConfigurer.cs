using System;
using Emte.Core.API.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Emte.Core.API
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerServices<T>(this IServiceCollection services, string appName)
            where T : ISwaggerConfig
        {
            services.AddSwaggerGen(c =>
            {
                var openApiInfo = new OpenApiInfo
                {
                    Title = appName,
                    Version = "v1",
                };

                c.OperationFilter<IgnoreODataQueryOptionsFilter>();
                c.SwaggerDoc("v1", openApiInfo);
                c.CustomSchemaIds(x => x.FullName);
                var documentXml = $"{appName}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, documentXml));
                c.OperationFilter<AddCustomSwaggerHeaderFilter<T>>();
                c.UseInlineDefinitionsForEnums();
            });
        }

        public static void AddSwaggerWeb<T>(this IApplicationBuilder app, IOptionsMonitor<T> config, string appName)
            where T : ISwaggerConfig
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/swagger"))
                {
                    context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(config.CurrentValue.SwaggerResponseCacheAgeSeconds)
                    };
                }

                await next();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", appName);
                c.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
                c.ConfigObject.AdditionalItems.Add("theme", "agate");
            });
        }
    }
}
