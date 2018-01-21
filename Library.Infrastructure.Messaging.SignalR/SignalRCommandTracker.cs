using Library.Domain.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Library.Infrastructure.Messaging.SignalR
{
	public class SignalRCommandTracker : ICommandTracker
	{
		private ISignalRConnectionProvider _provider = null;

		public SignalRCommandTracker(ISignalRConnectionProvider provider)
		{
			_provider = provider;
		}

		private string Url
		{
			get
			{
				return _provider.Url;
			}
		}

		public void Track(Guid commandUniqueId, List<string> eventNames)
		{
			ApiRequest.Post($"{Url}/api/monitored_commands", new
			{
				CommandUniqueId = commandUniqueId,
				EventNames = eventNames
			});
		}

		public void Finish(Guid commandUniqueId, string eventName)
		{
			ApiRequest.Put($"{Url}/api/monitored_commands/{commandUniqueId}/events/{eventName}", new { Status = "0" });
		}

		public void DirectFinish(Guid commandUniqueId)
		{
			ApiRequest.Put($"{Url}/api/monitored_commands/{commandUniqueId}", new { Status = "0" });
		}

		public void DirectError(Guid commandUniqueId, string errorCode, string errorMessage)
		{
			ApiRequest.Put($"{Url}/api/monitored_commands/{commandUniqueId}", new { Status = "1", ErrorCode = errorCode, errorMessage = errorMessage });
		}

		public void Error(Guid commandUniqueId, string eventName, string errorCode, string errorMessage)
		{
			var data = new NameValueCollection();
			data.Add("Status", "1");
			data.Add("ErrorCode", errorCode);
			data.Add("ErrorMessage", errorMessage);

			if (string.IsNullOrEmpty(eventName))
			{
				ApiRequest.Put($"{Url}/api/monitored_commands/{commandUniqueId}", new
				{
					Status = "1",
					ErrorCode = errorCode,
					ErrorMessage = errorMessage
				});
			}
			else
			{
				ApiRequest.Put($"{Url}/api/monitored_commands/{commandUniqueId}/events/{eventName}", new
				{
					Status = "1",
					ErrorCode = errorCode,
					ErrorMessage = errorMessage
				});
			}
		}
	}
}