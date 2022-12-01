using System;
using Emte.Core.Authentication.Contract;

namespace Emte.Core.Authentication.Impl
{
	public class AuthenticationResponse : IAuthenticationResponse
	{
        public AuthenticationResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public AuthenticationResponse(string accessToken, string refreshToken)
        {
            IsSuccess = true;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}

