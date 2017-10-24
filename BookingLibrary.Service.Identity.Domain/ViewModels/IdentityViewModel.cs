using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain.ViewModels
{
    public class IdentityViewModel
    {
        public Guid UserId { get; set; }

        public string Role { get; set; }
    }
}