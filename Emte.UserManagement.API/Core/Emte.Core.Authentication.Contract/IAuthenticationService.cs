using System;
namespace Emte.Core.Authentication.Contract
{
	public interface IAuthenticationService<T>
	{
		Task<T> RegisterUser(IRegisterRequest registerRequest, CancellationToken cancellationToken);
		Task<IAuthenticationResponse> Login(LoginRequest loginRequest, CancellationToken cancellationToken);
    }
}

