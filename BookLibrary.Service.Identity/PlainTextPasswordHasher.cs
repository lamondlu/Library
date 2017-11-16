using System;
using BookLibrary.Service.Identity.Domain;

namespace BookLibrary.Service.Identity
{
    public class PlainTextPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }
    }
}