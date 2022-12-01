using System;
namespace Emte.Core.Authentication.Contract
{
	public interface ITokenValidator
	{
		bool ValidateToken(string token);
	}
}

