using System;
using AutoMapper;
using Emte.UserManagement.BusinessLogic.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Emte.UserManagement.BusinessLogic
{
	public static class BusinessLogicRegistrar
	{
		public static void Register(IServiceCollection services)
		{
            services.AddAutoMapper((mc) => mc.AddProfiles(new[]
            {
                new UserManagementProfiles()
            }));
            services.AddTransient<ITenantService, TenantService>();
        }
	}
}

