using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI.DTOs
{
    public class IdentityDTO
    {
        public Guid UserId { get; set; }

        public string Role { get; set; }
    }
}