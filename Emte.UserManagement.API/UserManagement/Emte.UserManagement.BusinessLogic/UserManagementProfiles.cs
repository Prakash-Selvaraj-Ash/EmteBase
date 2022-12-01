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
			CreateMap<CreateUserRequest, AppUser>()
				.ForMember(t => t.Id, opts => opts.Ignore())
				.ForMember(t => t.FirstName, opts => opts.MapFrom(o => o.FirstName))
				.ForMember(t => t.LastName, opts => opts.MapFrom(o => o.LastName))
				.ForMember(t => t.Email, opts => opts.MapFrom(o => o.Email));

			CreateMap<Tenant, CreateUserRequest>()
				.ForMember(u => u.FirstName, opts => opts.MapFrom(o => o.Name))
				.ForMember(u => u.LastName, opts => opts.MapFrom(o => o.Name))
				.ForMember(u => u.Email, opts => opts.MapFrom(o => o.Email))
                .ForMember(u => u.Password, opts => opts.MapFrom(o => Guid.NewGuid().ToString("d").Substring(1, 8)))
                .ForMember(t => t.ConfirmPassword, opts => opts.Ignore());
        }
	}
}

