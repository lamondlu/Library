using System;
using System.Collections.Generic;

namespace Library.Domain.Core.Messaging
{
	public interface ICommandTracker
	{
		void Track(Guid commandUniqueId, List<string> eventNames);

		void Finish(Guid commandUniqueId, string eventName);

		void Error(Guid commandUniqueId, string eventName, string errorCode, string errorMessage);

		void DirectFinish(Guid commandUniqueId);

		void DirectError(Guid commandUniqueId, string errorCode, string errorMessage);
	}
}