using System;
using System.ComponentModel.DataAnnotations;

namespace Emte.Core.Authentication.Contract
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

