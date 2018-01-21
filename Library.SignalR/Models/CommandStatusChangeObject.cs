using System;

namespace Library.SignalR.Models
{
	public class CommandStatusChangeObject
	{
		public Guid CommandUniqueId { get; set; }

		public string EventName { get; set; }

		public string ErrorCode { get; set; }

		public string ErrorMessage { get; set; }

		public bool IsFinished { get; set; }

		public bool IsError { get; set; }
	}
}