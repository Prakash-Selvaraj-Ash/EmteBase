using System;
using Emte.Core.Authentication.Contract;
namespace Emte.UserManagement.Models.Request
{
	public class CreateUserRequest : IRegisterRequest
	{
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}

