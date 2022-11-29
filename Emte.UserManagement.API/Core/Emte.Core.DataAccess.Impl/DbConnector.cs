using System;
using Emte.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Emte.Core.DataAccess
{
    public class DbConnector<T> : IQueryableConnector<T>
        where T : DbContext
    {
        private readonly T _appDbContext;
        public DbConnector(T appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<TDomain> GetDbSet<TDomain>()
            where TDomain : class, IDomain
        {
            return _appDbContext.Set<TDomain>();
        }

        public TDomain Create<TDomain>(TDomain domain)
            where TDomain : class, IDomain
        {
            var set = _appDbContext.Set<TDomain>();
            var result = set.Add(domain);
            return result.Entity;
        }

        public IQueryable<TDomain> ReadAll<TDomain>()
            where TDomain : class, IDomain
        {
            var set = _appDbContext.Set<TDomain>();
            return set;
        }

        public TDomain ReadById<TDomain>(Guid id)
            where TDomain : class, IDomain
        {
            var set = _appDbContext.Set<TDomain>();
            return set.Find(id);
        }

        public void DeleteAll<TDomain>()
            where TDomain : class, IDomain
        {
            var items = _appDbContext.Set<TDomain>().ToArray();
            _appDbContext.Set<TDomain>().RemoveRange(items.ToArray());
        }

        public IQueryable<TDomain> ReadByIds<TDomain>(Guid[] ids)
            where TDomain : class, IDomain, IWithId
        {
            var set = _appDbContext.Set<TDomain>();
            return set.Where(domain => ids.Contains(domain.Id));
        }

        public TDomain Update<TDomain>(TDomain domain)
            where TDomain : class, IDomain
        {
            var set = _appDbContext.Set<TDomain>();
            var updatedSet = set.Update(domain);
            return updatedSet.Entity;
        }

        public async Task<EntityEntry<TDomain>> CreateAsync<TDomain>(TDomain domain, CancellationToken cancellationToken)
            where TDomain : class, IDomain
        {
            var set = _appDbContext.Set<TDomain>();
            return await set.AddAsync(domain, cancellationToken);
        }

        public async Task<TDomain> ReadByIdAsync<TDomain>(Guid id, CancellationToken cancellationToken)
            where TDomain : class, IDomain
        {
            var set = _appDbContext.Set<TDomain>();
            return await set.FindAsync(id);
        }

        public async Task<TDomain[]> ReadAllAsync<TDomain>(CancellationToken token)
            where TDomain : class, IDomain
        {
            var set = _appDbContext.Set<TDomain>();
            return await set.ToArrayAsync(token);
        }

        public async Task<TDomain[]> ReadByIdsAsync<TDomain>(Guid[] ids, CancellationToken token)
            where TDomain : class, IDomain, IWithId
        {
            var set = _appDbContext.Set<TDomain>();
            return await set.Where(domain => ids.Contains(domain.Id)).ToArrayAsync(token);
        }

        public async Task DeleteByIds<TDomain>(Guid[] ids, CancellationToken cancellationToken)
            where TDomain : class, IDomain, IWithId
        {
            var set = _appDbContext.Set<TDomain>();
            var entriesTobeRemoved = await set.Where(domain => ids.Contains(domain.Id)).ToArrayAsync();

            set.RemoveRange(entriesTobeRemoved);
        }

        public async Task CreateMultipleAsync<TDomain>(TDomain[] domain, CancellationToken cancellationToken)
            where TDomain : class, IDomain
        {
            var set = _appDbContext.Set<TDomain>();
            await set.AddRangeAsync(domain, cancellationToken);
        }

        public async Task<TDomain> ReadByIdAsync<TDomain>(string id, CancellationToken cancellationToken)
            where TDomain : class, IDomain
        {
            var set = _appDbContext.Set<TDomain>();
            return await set.FindAsync(id, cancellationToken);
        }

        public IQueryable<TDomain> FromSQL<TDomain>(string sqlQuery)
            where TDomain : class, IDomain
        {
            var set = _appDbContext.Set<TDomain>();
            return set;
        }
    }
}

