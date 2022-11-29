using System;
using Microsoft.EntityFrameworkCore;

namespace Emte.Core.DataAccess
{
	public abstract class BaseDbContext : DbContext
	{
		public BaseDbContext()
		{
		}

        public abstract Task MigrateAsync(CancellationToken cancellationToken);
    }
}

