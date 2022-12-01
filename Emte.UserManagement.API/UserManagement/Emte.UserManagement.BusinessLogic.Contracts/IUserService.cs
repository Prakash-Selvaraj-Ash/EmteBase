using System;
using Emte.UserManagement.DomainModels;

namespace Emte.UserManagement.BusinessLogic.Contracts
{
	public interface IUserService
	{
		Task<AppUser> CreateAdminUser(AppUser appUser, CancellationToken cancellationToken);
	}
}

