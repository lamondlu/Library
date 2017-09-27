using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core
{
    public class Person : Entity
    {
        public Person(Guid personId, PersonName name)
        {
            this.PersonId = personId;
            this.Name = name;
        }

        public Person(PersonName name) : this(Guid.NewGuid(), name)
        {

        }

        public Guid PersonId { get; private set; }

        public PersonName Name { get; set; }


    }
}
