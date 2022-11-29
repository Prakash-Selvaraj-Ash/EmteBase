using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Emte.Core.DataAccess.Impl;
public class EntityService<T> : IEntityService<T>
    where T : BaseDbContext
{
    private readonly T _context;

    public EntityService(T context)
    {
        _context = context;
    }

    public IDbContextTransaction GetOrBeginTransaction()
    {
        return _context.Database.CurrentTransaction ?? _context.Database.BeginTransaction();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        await _context.MigrateAsync(cancellationToken);
    }
}

