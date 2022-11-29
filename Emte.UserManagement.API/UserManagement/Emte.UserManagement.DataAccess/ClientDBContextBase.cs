using System;
using Emte.Core.DataAccess;
using Emte.UserManagement.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Emte.UserManagement.DataAccess
{
	public abstract class ClientDBContextBase : BaseDbContext
	{
		public ClientDBContextBase() { }
		
        public DbSet<AppUser>? User { get; set; }
    }
}

