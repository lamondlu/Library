using System;
using  Library.Service.Identity.Domain;

namespace  Library.Service.Identity
{
    public class PlainTextPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }
    }
}