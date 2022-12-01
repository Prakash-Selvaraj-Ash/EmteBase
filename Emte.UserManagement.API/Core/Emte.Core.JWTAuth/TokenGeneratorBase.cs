using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Emte.Core.JWTAuth
{
	public class TokenGeneratorBase
	{
		public string GenerateCoreToken(string secretKey,
			string issuer,
			string audience,
            double expiration,
			Dictionary<string, string> claims = null)
		{
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> _claims = new List<Claim> { };
            if(claims != null)
            {
                foreach (var claim in claims)
                {
                    _claims.Add(new Claim(claim.Key, claim.Value));
                }
            }
            JwtSecurityToken token = new JwtSecurityToken(
                issuer,
                audience,
                _claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(expiration),
                creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
	}
}

