using System;
using System.ComponentModel.DataAnnotations.Schema;
using Emte.Core.DomainModels;

namespace Emte.UserManagement.DomainModels
{
	public class AppUserTokenMap : IDomain, IWithId
	{
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual AppUser? AppUser { get; set; }
        public string? Token { get; set; }
    }
}

