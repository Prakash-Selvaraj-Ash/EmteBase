using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Emte.Core.Authentication.Contract;
using Microsoft.IdentityModel.Tokens;

namespace Emte.Core.JWTAuth
{
	public class JWTTokenValidator : ITokenValidator
	{
        private readonly IAuthConfig jWTConfiguration;

        public JWTTokenValidator(IAuthConfig jWTConfiguration)
        {
            this.jWTConfiguration = jWTConfiguration;
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var param = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTConfiguration.AccessTokenSecretKey)),
                    ValidIssuer = jWTConfiguration.Issuer,
                    ValidAudience = jWTConfiguration.Audience,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };
                JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();
                _handler.ValidateToken(token, param, out SecurityToken securityToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

