using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core
{
    public struct PersonName
    {
        public PersonName(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string MiddleName { get; private set; }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            else
            {
                return FirstName == ((PersonName)obj).FirstName
                && MiddleName == ((PersonName)obj).MiddleName
                && LastName == ((PersonName)obj).LastName;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(PersonName o1, PersonName o2)
        {
            if (o1 == null || o2 == null)
            {
                return false;
            }

            return o1.FirstName == o2.FirstName
                && o1.MiddleName == o2.MiddleName
                && o1.LastName == o2.LastName;
        }

        public static bool operator !=(PersonName o1, PersonName o2)
        {
            return !(o1 == o2);
        }
    }
}
