using System;

namespace Library.UI.SessionStorages
{
	public interface ISessionStorage : IDisposable
	{
		T Get<T>(string key);

		void Set<T>(string key, T value);
	}
}