using System;
using Emte.Core.Authentication.Contract;

namespace Emte.ClientApplication.MicroService.API
{
	public class AppConfig
	{
		public AuthenticationConfiguration? Authentication { get; set; }
	}

    public class AuthenticationConfiguration : IAuthConfig
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? RefreshTokenSecretKey { get; set; }
        public string? AccessTokenSecretKey { get; set; }
        public double RefreshTokenExpiration { get; set; }
        public double AccessTokenExpiration { get; set; }
    }
}

