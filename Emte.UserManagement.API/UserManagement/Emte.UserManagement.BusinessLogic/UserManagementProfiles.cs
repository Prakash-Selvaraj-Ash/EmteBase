using System;
using AutoMapper;
using Emte.UserManagement.DomainModels;
using Emte.UserManagement.Models;
using Emte.UserManagement.Models.Request;
using Emte.UserManagement.Models.Response;

namespace Emte.UserManagement.BusinessLogic
{
	public class UserManagementProfiles : Profile
	{
		public UserManagementProfiles()
		{
			CreateMap<CreateTenantRequest, Tenant>()
				.ForMember(t => t.StatusId, opts => opts.Ignore())
				.ForMember(t => t.Status, opts => opts.Ignore());
			CreateMap<Tenant, CreateTenantResponse>();
		}
	}
}

