using System;
using Emte.Core.DomainModels;

namespace Emte.Core.Repository.Contracts
{
    public interface IWithCodeRepository<TDomain> : IRepository<TDomain>
        where TDomain : class, IDomain, IWithCode
    {
        Task<TDomain> ReadByCodeAsync(string code, CancellationToken cancellationToken = default(CancellationToken));
    }
}

