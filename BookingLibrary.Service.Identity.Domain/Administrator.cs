using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public class Administrator : Person
    {
        public Administrator(PersonName name) : base(name)
        {
        }

        public Administrator(Guid personId, PersonName name) : base(personId, name)
        {
            
        }
    }
}