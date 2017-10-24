using System;
using BookingLibrary.Service.Identity.Domain;

namespace BookingLibrary.Service.Identity
{
    public class PlainTextPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }
    }
}