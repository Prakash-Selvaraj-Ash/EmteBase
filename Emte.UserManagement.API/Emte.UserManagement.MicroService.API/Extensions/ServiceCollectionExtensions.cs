using System;
using System.Data.Common;
using System.Runtime.ConstrainedExecution;
using Emte.Core.API;
using Emte.Core.Authentication.Contract;
using Emte.Core.Authentication.Impl;
using Emte.Core.DataAccess;
using Emte.Core.DataAccess.Impl;
using Emte.UserManagement.API.DataAccess;
using Emte.UserManagement.DataAccess;
using Emte.UserManagement.DomainModels;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Emte.UserManagement.API.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static void RegisterServiceCollection(this IServiceCollection services, IConfiguration configuration)
        { 
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Host DB
            services.AddDbContext<TenantDbContext>();

            // Client DB
            services.AddDbContext<ClientDbContext>();

            RegisterCore(services);

            BusinessLogic.BusinessLogicRegistrar.Register(services);
            Repository.RepositoryRegistrar.Register(services);
            services.AddTransient<IAuthenticationService<AppUser>, AuthenticationService<AppUser>>();
        }

        private static void RegisterCore(IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddScoped<TenantDbContextBase, TenantDbContext>();
            services.AddScoped<ClientDBContextBase, ClientDbContext>();
            services.AddScoped<IEntityService<TenantDbContextBase>, EntityService<TenantDbContextBase>>();
            services.AddScoped<IEntityService<ClientDBContextBase>, EntityService<ClientDBContextBase>>();
            services.AddTransient<IQueryableConnector<TenantDbContextBase>, DbConnector<TenantDbContextBase>>();
            services.AddTransient<IQueryableConnector<ClientDBContextBase>, DbConnector<ClientDBContextBase>>();
        }
    }
}

