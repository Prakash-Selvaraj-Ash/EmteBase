using System;
using Emte.Core.Authentication.Contract;
using Emte.UserManagement.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Emte.UserManagement.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IAuthenticationService<AppUser> _authenticationService;

        public UserController(IAuthenticationService<AppUser> authenticationService)
		{
            _authenticationService = authenticationService;
		}

        [HttpPost("Login")]
        public async Task<IAuthenticationResponse> Login(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            return await _authenticationService.Login(loginRequest, cancellationToken);
        }
	}
}

