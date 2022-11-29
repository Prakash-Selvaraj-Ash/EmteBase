using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace Emte.Core.API.Filters
{
    public class AddCustomSwaggerHeaderFilter<T> : IOperationFilter
        where T : ISwaggerConfig
    {
        private readonly T _config;

        public AddCustomSwaggerHeaderFilter(IOptionsMonitor<T> config)
        {
            _config = config.CurrentValue;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            AddOpenApiHeaders(operation);
        }

        private void AddOpenApiHeaders(OpenApiOperation operation)
        {
            var apiHeaders = _config.SwaggerCustomHeaders;
            if (apiHeaders?.Any() == true)
            {
                foreach (var apiHeader in apiHeaders)
                {
                    var openApiParameter = new OpenApiParameter
                    {
                        Name = apiHeader.Name,
                        Required = apiHeader.Required,
                        Description = apiHeader.Description,
                        In = apiHeader.Location
                    };

                    var openApiSchema = new OpenApiSchema
                    {
                        Type = apiHeader.Type
                    };

                    if (!string.IsNullOrEmpty(apiHeader.DefaultValue))
                    {
                        openApiSchema.Default = new OpenApiString(apiHeader.DefaultValue);
                    }

                    openApiParameter.Schema = openApiSchema;
                    operation.Parameters.Add(openApiParameter);
                }
            }
        }
    }
}


