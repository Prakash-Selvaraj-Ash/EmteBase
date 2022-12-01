using System;
namespace Emte.Core.API
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashPassword);
    }
}

