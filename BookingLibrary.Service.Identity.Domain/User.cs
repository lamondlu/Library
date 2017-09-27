using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public class User : Person
    {
        public User(PersonName name) : base(name)
        {
        }

        public User(Guid personId, PersonName name) : base(personId, name)
        {
            
        }
    }
}
