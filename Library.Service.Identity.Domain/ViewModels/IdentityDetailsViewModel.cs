using System;
using System.Collections.Generic;
using System.Text;

namespace  Library.Service.Identity.Domain
{
    public class IdentityDetailsViewModel
    {
        public Guid AccountId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}
