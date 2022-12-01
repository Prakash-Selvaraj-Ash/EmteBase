using System;
using Emte.Core.DataAccess;
using Emte.Core.Repository.Contracts;
using Emte.UserManagement.DataAccess;
using Emte.UserManagement.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Emte.UserManagement.Repository
{
	public class UserRepository<T> : RepositoryBase<AppUser, T>, IRepository<AppUser>, IUserRepository<AppUser>
    where T : ClientDBContextBase
    {
        public UserRepository(IQueryableConnector<T> queryableConnector) : base(queryableConnector)
        {
        }

        public async Task<AppUser> CreateUser(AppUser user, CancellationToken cancellationToken)
        {
            return (await CreateAsync(user, cancellationToken)).Entity;
        }

        public Task<AppUser?> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            return Set.SingleOrDefaultAsync(u => u.Email!.Equals(email), cancellationToken);
        }
    }
}

