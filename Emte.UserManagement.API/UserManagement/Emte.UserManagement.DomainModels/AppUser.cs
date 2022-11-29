using System;
using Emte.Core.DomainModels;

namespace Emte.UserManagement.DomainModels
{
	public class AppUser : IDomain, IWithId
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
    }
}

