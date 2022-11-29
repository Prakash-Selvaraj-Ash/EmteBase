using System;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Emte.Core.API.Filters
{
    public class IgnoreODataQueryOptionsFilter : IOperationFilter
    {
        private const string ODataQueryOptions = "ODataQueryOptions";

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var toRemoveParameter = operation?.Parameters?.FirstOrDefault(desc =>
            !string.IsNullOrEmpty(desc.Schema?.Reference?.Id)
            && desc.Schema.Reference.Id.Contains(ODataQueryOptions, StringComparison.OrdinalIgnoreCase));

            if (toRemoveParameter != null)
            {
                operation!.Parameters.Remove(toRemoveParameter);
            }
        }
    }
}

