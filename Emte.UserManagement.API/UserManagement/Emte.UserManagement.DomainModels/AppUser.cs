using System;
using Emte.Core.DomainModels;

namespace Emte.UserManagement.DomainModels
{
	public class AppUser : IDomain, IWithId, IUserDomain
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? HashedPassword { get; set; }
    }
}

