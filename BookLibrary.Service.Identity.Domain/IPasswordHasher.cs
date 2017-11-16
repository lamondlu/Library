using System;
using BookLibrary.Domain.Core;

namespace BookLibrary.Service.Identity.Domain
{
    public interface IPasswordHasher 
    {
        string HashPassword(string password);
    }
}