using System;
namespace Emte.UserManagement.Models.Request
{
	public class CreateTenantRequest
	{
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}

