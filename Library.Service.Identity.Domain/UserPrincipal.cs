using System;
using  Library.Domain.Core;

namespace  Library.Service.Identity.Domain
{
    public abstract class UserPrincipal : ValueObject
    {
        public UserPrincipal(string role, string userName, string password)
        {
            this.Role = role;
            this.UserName = userName;
            this.Password = password;
        }

        public string Role { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public bool Validate(string userName, string password, IPasswordHasher passwordHasher)
        {
            return UserName == userName && passwordHasher.HashPassword(password) == password;
        }
    }
}