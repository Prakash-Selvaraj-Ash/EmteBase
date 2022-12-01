using System;
using Emte.Core.Authentication.Contract;

namespace Emte.Core.JWTAuth
{
	public class RefreshTokenGenerator: TokenGeneratorBase, IRefreshTokenGenerator
	{
        public string GenerateToken(string secretKey, string issuer, string audience, double expiration, Dictionary<string, string> claims = null)
        {
            return GenerateCoreToken(secretKey, issuer, audience, expiration);
        }
    }
}

