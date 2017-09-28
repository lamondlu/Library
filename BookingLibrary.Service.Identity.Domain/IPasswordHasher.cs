using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public interface IPasswordHasher 
    {
        string HashPassword(string password);
    }
}