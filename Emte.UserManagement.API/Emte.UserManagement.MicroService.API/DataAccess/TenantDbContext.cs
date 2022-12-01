using System;
using Emte.Core.DataAccess;
using Emte.UserManagement.API.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Emte.UserManagement.DomainModels;
using Emte.UserManagement.DataAccess;

namespace Emte.UserManagement.API.DataAccess
{
	public class TenantDbContext : TenantDbContextBase
	{
        private readonly AppConfig _appConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantDbContext(
			IOptionsMonitor<AppConfig> config,
            IHttpContextAccessor httpContextAccessor)
		{
			_appConfig = config.CurrentValue;
			_httpContextAccessor = httpContextAccessor;
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = GetHostConnectionString();
            optionsBuilder.UseMySql(tenantConnectionString, ServerVersion.AutoDetect(tenantConnectionString));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedTenant();

            modelBuilder.Entity<Tenant>()
                .HasOne(t => t.Status);
        }

        private string GetHostConnectionString()
        {
            return _appConfig.ConnectionStrings?.DefaultConnection!;
        }

        public override Task MigrateAsync(CancellationToken cancellationToken)
        {
            return Database.MigrateAsync(cancellationToken);
        }
    }
}

