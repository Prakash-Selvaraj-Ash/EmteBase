using System.Text;
using Emte.Core.Authentication.Contract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Emte.Core.JWTAuth;
public static class JWTRegistrar
{
    public static void InitializeJWTAuthentication(this IServiceCollection services, IAuthConfig jWTConfiguration)
    {
        services.AddTransient<ITokenValidator, JWTTokenValidator>();
        services.AddTransient<IAccessTokenGenerator, AccessTokenGenerator>();
        services.AddTransient<IRefreshTokenGenerator, RefreshTokenGenerator>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTConfiguration.AccessTokenSecretKey)),
                ValidIssuer = jWTConfiguration.Issuer,
                ValidAudience = jWTConfiguration.Audience,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };
        });
    }
}

