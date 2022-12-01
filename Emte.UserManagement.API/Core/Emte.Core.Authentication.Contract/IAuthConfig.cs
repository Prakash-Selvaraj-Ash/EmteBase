using System;
namespace Emte.Core.Authentication.Contract
{
	public interface IAuthConfig
	{
        string RefreshTokenSecretKey { get; set; }
        string AccessTokenSecretKey { get; set; }
        string Issuer { get; set; }
        string Audience { get; set; }
        double AccessTokenExpiration { get; set; }
        double RefreshTokenExpiration { get; set; }
    }
}

