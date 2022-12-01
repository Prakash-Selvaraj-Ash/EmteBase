namespace Emte.Core.Authentication.Contract;
public interface ITokenGenerator
{
    string GenerateToken(
        string secretKey,
        string issuer,
        string audience,
        double expiration,
        Dictionary<string, string> claims = null);
}

public interface IAccessTokenGenerator : ITokenGenerator { }
public interface IRefreshTokenGenerator : ITokenGenerator { }

