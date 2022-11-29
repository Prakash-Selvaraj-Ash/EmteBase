using System;
namespace Emte.Core.DomainModels
{
	public class BaseStatus
	{
		public Guid StatusId { get; set; }
		public string? Name { get; set; }
		public string? Code { get; set; }
	}
}

