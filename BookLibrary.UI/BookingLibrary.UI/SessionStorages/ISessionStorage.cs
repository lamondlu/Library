using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.UI.SessionStorages
{
    public interface ISessionStorage
    {
        T Get<T>(string key);

        void Set<T>(string key, T value);
    }
}
