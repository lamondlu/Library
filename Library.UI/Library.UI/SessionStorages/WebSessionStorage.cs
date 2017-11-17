using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI.SessionStorages
{
    public class WebSessionStorage : ISessionStorage
    {
        public T Get<T>(string key)
        {
            return (T)HttpContext.Current.Session[key];
        }

        public void Set<T>(string key, T value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public void Dispose()
        {
            
        }
    }
}