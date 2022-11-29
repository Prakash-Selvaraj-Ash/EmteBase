using System;
namespace Emte.UserManagement.Models
{
	public class TenantModel
	{
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}

