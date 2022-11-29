using System.Collections.Generic;
using Emte.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Emte.Core.Repository.Contracts;
public interface IRepository<TDomain>
        where TDomain : class, IDomain
{
    IQueryable<TDomain> FromSQL(string sqlQuery);
    IQueryable<TDomain> GetAll();
    TDomain ReadById(Guid id);
    IQueryable<TTDomain> ReadByIds<TTDomain>(Guid[] ids)
        where TTDomain : class, IDomain, IWithId, new();
    TDomain Update(TDomain domain);
    TDomain Create(TDomain domain);
    void DeleteAll();
    Task DeleteByIds<TTDomain>(Guid[] ids, CancellationToken token)
        where TTDomain : class, IDomain, IWithId, new();
    Task<TDomain[]> GetAllAsync(CancellationToken token);
    Task<EntityEntry<TDomain>> CreateAsync(TDomain domain, CancellationToken token);
    Task CreateMultipleAsync(TDomain[] domains, CancellationToken cancellationToken);
    Task<TDomain> ReadByIdAsync(Guid id, CancellationToken token);
    Task<TTDomain[]> ReadByIdsAsync<TTDomain>(Guid[] ids, CancellationToken token)
        where TTDomain : class, IDomain, IWithId, new();
    Task<TDomain> ReadByIdAsync(string id, CancellationToken token);
    DbSet<TDomain> Set { get; }
}

