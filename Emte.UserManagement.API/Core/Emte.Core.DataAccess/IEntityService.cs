using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Emte.Core.DataAccess
{
    public interface IEntityService<T>
        where T : DbContext
    {
        IDbContextTransaction GetOrBeginTransaction();

        void Save();

        Task SaveAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task MigrateAsync(CancellationToken cancellationToken);
    }
}

