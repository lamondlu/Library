using System;

namespace Library.CoreUI.SessionStorages
{
	public interface ISessionStorage : IDisposable
	{
		T Get<T>(string key);

		void Set<T>(string key, T value);
	}
}