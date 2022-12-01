using System;
using Emte.Core.Repository.Contracts;
using Emte.UserManagement.BusinessLogic.Contracts;
using Emte.UserManagement.DomainModels;

namespace Emte.UserManagement.BusinessLogic
{
	public class UserService : IUserService
	{
        private readonly IUserRepository<AppUser> _userRepository;

        public UserService(IUserRepository<AppUser> userRepository)
		{
			_userRepository = userRepository;
		}

        public Task<AppUser> CreateAdminUser(AppUser appUser, CancellationToken cancellationToken)
        {
            return _userRepository.CreateUser(appUser, cancellationToken);
        }
    }
}

