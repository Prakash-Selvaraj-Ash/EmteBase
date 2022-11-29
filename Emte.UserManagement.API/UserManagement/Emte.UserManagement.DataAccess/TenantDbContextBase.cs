using Emte.Core.DataAccess;
using Emte.UserManagement.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Emte.UserManagement.DataAccess;
public abstract class TenantDbContextBase : BaseDbContext
{
    public DbSet<Tenant>? Tenants { get; set; }
}

