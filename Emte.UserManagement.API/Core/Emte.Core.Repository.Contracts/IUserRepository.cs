using System;
using Emte.Core.DomainModels;

namespace Emte.Core.Repository.Contracts
{
	public interface IUserRepository<T> : IRepository<T> where T : class, IDomain, IUserDomain
	{
        Task<T?> GetUserByEmail(string email, CancellationToken cancellationToken);
        Task<T> CreateUser(T user, CancellationToken cancellationToken);
    }
}

