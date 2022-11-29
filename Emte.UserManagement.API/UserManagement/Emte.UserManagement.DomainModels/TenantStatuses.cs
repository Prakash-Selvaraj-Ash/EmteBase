using System;
using Emte.Core.DomainModels;

namespace Emte.UserManagement.DomainModels
{
	public class TenantStatuses : IDomain, IWithId, IWithName
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
	}
}

