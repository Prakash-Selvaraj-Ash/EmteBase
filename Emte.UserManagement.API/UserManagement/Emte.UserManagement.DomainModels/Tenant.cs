using System.ComponentModel.DataAnnotations.Schema;
using Emte.Core.DomainModels;

namespace Emte.UserManagement.DomainModels;
public class Tenant : IDomain, IWithId, IWithName
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public Guid StatusId { get; set; }
    [ForeignKey(nameof(StatusId))]
    public virtual TenantStatuses? Status { get; set; }
    public string? OtherDetails { get; set; }
}

