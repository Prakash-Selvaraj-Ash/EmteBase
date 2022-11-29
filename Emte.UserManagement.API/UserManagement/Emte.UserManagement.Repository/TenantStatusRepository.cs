using System;
using Emte.Core.DataAccess;
using Emte.Core.Repository.Contracts;
using Emte.UserManagement.DataAccess;
using Emte.UserManagement.DomainModels;

namespace Emte.UserManagement.Repository
{
	public class TenantStatusRepository<T> : RepositoryBase<TenantStatuses, T>, IRepository<TenantStatuses>
		where T : TenantDbContextBase
    {
        public TenantStatusRepository(IQueryableConnector<T> queryableConnector) : base(queryableConnector)
        {
        }
    }
}

