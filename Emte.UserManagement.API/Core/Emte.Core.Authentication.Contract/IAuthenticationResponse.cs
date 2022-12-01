using System;
namespace Emte.Core.Authentication.Contract
{
	public interface IAuthenticationResponse
	{
		bool IsSuccess { get; set; }
		string ErrorMessage { get; set; }
		string AccessToken { get; set; }
        string RefreshToken { get; set; }
    }
}

