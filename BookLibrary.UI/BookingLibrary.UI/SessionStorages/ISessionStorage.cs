using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.UI.SessionStorages
{
    public interface ISessionStorage : IDisposable
    {
        T Get<T>(string key);

        void Set<T>(string key, T value);
    }
}
