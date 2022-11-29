using System;
using Emte.Core.API;

namespace Emte.UserManagement.API.Configuration
{
	public class AppConfig : ISwaggerConfig
	{
        public bool MultiTenancyEnabled { get; set; }

        public Connection? ConnectionStrings { get; set; }

        public int SwaggerResponseCacheAgeSeconds { get; set; }

        public IList<SwaggerCustomHeader>? SwaggerCustomHeaders { get; set; }
    }

    public class Connection
    {
        public string? DefaultConnection { get; set; }

        public string? ClientConnection { get; set; }
    }
}

