using System;
using Emte.Core.DataAccess;
using Emte.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Emte.Core.Repository.Contracts
{
    public class RepositoryBase<TDomain, TDBContext> : IRepository<TDomain>
    where TDomain : class, IDomain, new()
    {
        public IQueryableConnector<TDBContext> Connector { get; }

        public DbSet<TDomain> Set { get { return Connector.GetDbSet<TDomain>(); } }

        public RepositoryBase(IQueryableConnector<TDBContext> queryableConnector)
        {
            Connector = queryableConnector;
        }

        public IQueryable<TDomain> GetAll()
        {
            return Connector.ReadAll<TDomain>();
        }

        public TDomain ReadById(Guid id)
        {
            return Connector.ReadById<TDomain>(id);
        }

        public TDomain Update(TDomain domain)
        {
            return Connector.Update(domain);
        }

        public TDomain Create(TDomain domain)
        {
            return Connector.Create(domain);
        }

        public IQueryable<TTDomain> ReadByIds<TTDomain>(Guid[] ids)
            where TTDomain : class, IDomain, IWithId, new()
        {
            return Connector.ReadByIds<TTDomain>(ids);
        }

        public void DeleteAll()
        {
            Connector.DeleteAll<TDomain>();
        }

        public async Task<TDomain[]> GetAllAsync(CancellationToken token)
        {
            return await Connector.ReadAllAsync<TDomain>(token);
        }

        public async Task<EntityEntry<TDomain>> CreateAsync(TDomain domain, CancellationToken token)
        {
            return await Connector.CreateAsync(domain, token);
        }

        public async Task CreateMultipleAsync(TDomain[] domains, CancellationToken token)
        {
            await Connector.CreateMultipleAsync(domains, token);
        }

        public async Task<TDomain> ReadByIdAsync(Guid id, CancellationToken token)
        {
            return await Connector.ReadByIdAsync<TDomain>(id, token);
        }

        public async Task<TTDomain[]> ReadByIdsAsync<TTDomain>(Guid[] ids, CancellationToken token)
            where TTDomain : class, IDomain, IWithId, new()
        {
            return await Connector.ReadByIdsAsync<TTDomain>(ids, token);
        }

        public async Task DeleteByIds<TTDomain>(Guid[] ids, CancellationToken token)
            where TTDomain : class, IDomain, IWithId, new()
        {
            await Connector.DeleteByIds<TTDomain>(ids, token);
        }

        public async Task<TDomain> ReadByIdAsync(string id, CancellationToken token)
        {
            return await Connector.ReadByIdAsync<TDomain>(id, token);
        }

        public IQueryable<TDomain> FromSQL(string sqlQuery)
        {
            return Connector.FromSQL<TDomain>(sqlQuery);
        }
    }
}

