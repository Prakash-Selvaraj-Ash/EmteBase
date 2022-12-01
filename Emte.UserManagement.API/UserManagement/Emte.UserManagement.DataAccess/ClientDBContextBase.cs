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
        public DbSet<AppUserTokenMap>? UserTokenMap { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUserTokenMap>().HasOne(au => au.AppUser);
        }
    }
}

