using System;
namespace Emte.Core.API
{
	public interface ISwaggerConfig
	{

        public int SwaggerResponseCacheAgeSeconds { get; set; }

        public IList<SwaggerCustomHeader> SwaggerCustomHeaders { get; set; }
    }
}

