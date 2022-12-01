using System;
namespace Emte.Core.DomainModels
{
	public interface IUserDomain : IWithId
	{
        string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}

