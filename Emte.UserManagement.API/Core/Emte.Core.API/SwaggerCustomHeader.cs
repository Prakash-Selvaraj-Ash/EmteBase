using System;
using Microsoft.OpenApi.Models;

namespace Emte.Core.API
{
    public class SwaggerCustomHeader
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public string Type { get; set; }
        public string DefaultValue { get; set; }
        public ParameterLocation Location { get; set; }
    }
}

