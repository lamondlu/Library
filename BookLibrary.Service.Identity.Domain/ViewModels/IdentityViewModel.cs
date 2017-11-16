using System;
using BookLibrary.Domain.Core;

namespace BookLibrary.Service.Identity.Domain.ViewModels
{
    public class IdentityViewModel
    {
        public Guid UserId { get; set; }

        public string Role { get; set; }
    }
}