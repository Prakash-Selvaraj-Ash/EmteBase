using System;
using Emte.UserManagement.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Emte.UserManagement.API.DataAccess
{
	public static class TenantDbModelBuiderExtensions
	{
        public static Guid TenantRequestedStatusId = new Guid("6c46f5d4-3c9d-4ef8-81fb-6c3b77670f12");
        public static Guid TenantApprovedStatusId = new Guid("6068e5e9-b69b-4811-b045-40041775dc36");
        public static void SeedTenant(this ModelBuilder modelBuilder)
        {
            SeedTenantStatus(modelBuilder);
        }

        private static void SeedTenantStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenantStatuses>().HasData(
                new TenantStatuses
                {
                    Id = TenantRequestedStatusId,
                    Name = "Requested"
                },
                new TenantStatuses
                {
                    Id = TenantApprovedStatusId,
                    Name = "Approved"
                });
        }
    }
}

