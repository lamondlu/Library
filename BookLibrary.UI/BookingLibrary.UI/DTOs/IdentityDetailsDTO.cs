using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI
{
    public class IdentityDetailsDTO
    {
        public Guid AccountId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}