using System;
namespace Emte.UserManagement.Models.Response
{
	public class CreateTenantResponse
	{
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}

