using System.Security.Claims;
using AutoMapper;
using Emte.Core.API;
using Emte.Core.Authentication.Contract;
using Emte.Core.DomainModels;
using Emte.Core.Repository.Contracts;

namespace Emte.Core.Authentication.Impl;
public class AuthenticationService<T> : IAuthenticationService<T>
    where T : class, IDomain, IUserDomain
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository<T> _userRepository;
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator;
    private readonly IAuthConfig _authConfig;
    private readonly IMapper _mapper;

    public AuthenticationService(
        IPasswordHasher passwordHasher,
        IUserRepository<T> userRepository,
        IAuthConfig authConfig,
        IAccessTokenGenerator accessTokenGenerator,
        IRefreshTokenGenerator refreshTokenGenerator,
        IMapper mapper)
    {
        _refreshTokenGenerator = refreshTokenGenerator;
        _accessTokenGenerator = accessTokenGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _authConfig = authConfig;
        _mapper = mapper;
    }

    public async Task<IAuthenticationResponse> Login(LoginRequest registerRequest, CancellationToken cancellationToken)
    {
        // to-do validate
        var user = await _userRepository.GetUserByEmail(registerRequest.Email, cancellationToken);
        if (user == null || !_passwordHasher.VerifyPassword(registerRequest.Password, user.HashedPassword)) { return new AuthenticationResponse("User UnAuthorized"); }

        string passwordHash = _passwordHasher.HashPassword(registerRequest.Password);

        var claimsDict = new Dictionary<string, string>();
        claimsDict.Add("Id", user.Id.ToString());
        claimsDict.Add(ClaimTypes.Email, user.Email);
        string accessToken = _accessTokenGenerator.GenerateToken(_authConfig.AccessTokenSecretKey, _authConfig.Issuer, _authConfig.Audience, _authConfig.AccessTokenExpiration, claimsDict);
        string refreshToken = _refreshTokenGenerator.GenerateToken(_authConfig.RefreshTokenSecretKey, _authConfig.Issuer, _authConfig.Audience, _authConfig.RefreshTokenExpiration);
        return new AuthenticationResponse(accessToken, refreshToken);
    }

    public async Task<T> RegisterUser(IRegisterRequest registerRequest, CancellationToken cancellationToken)
    {
        // to-do validate
        if (!registerRequest.Password!.Equals(registerRequest.ConfirmPassword)) { throw new Exception("Bad Request"); }
        var user = await _userRepository.GetUserByEmail(registerRequest.Email!, cancellationToken);
        if (user != null) { throw new Exception("user not available"); }

        string passwordHash = _passwordHasher.HashPassword(registerRequest.Password);

        var newUser = _mapper.Map<T>(registerRequest);
        newUser.HashedPassword = passwordHash;

        var createdUser = await _userRepository.CreateUser(newUser, cancellationToken);
        return createdUser;
    }
}

