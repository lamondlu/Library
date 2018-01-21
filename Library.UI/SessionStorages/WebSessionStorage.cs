using System.Web;

namespace Library.UI.SessionStorages
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