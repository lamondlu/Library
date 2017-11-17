using System;
using  Library.Domain.Core;

namespace  Library.Service.Identity.Domain
{
    public interface IPasswordHasher 
    {
        string HashPassword(string password);
    }
}