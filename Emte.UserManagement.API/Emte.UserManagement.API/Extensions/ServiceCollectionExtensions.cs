using System;
using System.Data.Common;
using System.Runtime.ConstrainedExecution;
using Emte.Core.DataAccess;
using Emte.Core.DataAccess.Impl;
using Emte.UserManagement.API.DataAccess;
using Emte.UserManagement.DataAccess;
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
        }

        private static void RegisterCore(IServiceCollection services)
        {
            services.AddScoped<TenantDbContextBase, TenantDbContext>();
            services.AddScoped<ClientDBContextBase, ClientDbContext>();
            services.AddScoped<IEntityService<TenantDbContextBase>, EntityService<TenantDbContextBase>>();
            services.AddScoped<IEntityService<ClientDBContextBase>, EntityService<ClientDBContextBase>>();
            services.AddTransient<IQueryableConnector<TenantDbContextBase>, DbConnector<TenantDbContextBase>>();
            services.AddTransient<IQueryableConnector<ClientDBContextBase>, DbConnector<ClientDBContextBase>>();
        }
    }
}

