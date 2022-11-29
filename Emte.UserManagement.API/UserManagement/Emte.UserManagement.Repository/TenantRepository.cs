using Emte.Core.DataAccess;
using Emte.UserManagement.DataAccess;
using Emte.Core.Repository.Contracts;
using Emte.UserManagement.DomainModels;
using System.Net;

namespace Emte.UserManagement.Repository;
public class TenantRepository<T> : RepositoryBase<Tenant, T>, IRepository<Tenant>
    where T : TenantDbContextBase
{
    public TenantRepository(IQueryableConnector<T> queryableConnector) : base(queryableConnector)
    {
    }
}

