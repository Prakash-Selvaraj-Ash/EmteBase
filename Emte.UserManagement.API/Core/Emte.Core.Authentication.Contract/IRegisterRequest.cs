using System;
using System.ComponentModel.DataAnnotations;

namespace Emte.Core.Authentication.Contract
{
	public interface IRegisterRequest
	{
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}

