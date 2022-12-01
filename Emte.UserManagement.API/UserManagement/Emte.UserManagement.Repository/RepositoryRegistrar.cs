using System;
using Emte.Core.Repository.Contracts;
using Emte.UserManagement.DataAccess;
using Emte.UserManagement.DomainModels;
using Microsoft.Extensions.DependencyInjection;

namespace Emte.UserManagement.Repository
{
	public static class RepositoryRegistrar
	{
		public static void Register(IServiceCollection services)
		{
			services.AddTransient<IRepository<Tenant>, TenantRepository<TenantDbContextBase>>();
            services.AddTransient<IRepository<TenantStatuses>, TenantStatusRepository<TenantDbContextBase>>();
			services.AddTransient<IUserRepository<AppUser>, UserRepository<ClientDBContextBase>>();
        }
	}
}

