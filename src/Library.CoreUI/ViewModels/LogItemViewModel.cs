using System;

namespace BookingLibrary.CoreUI.Models
{
	public class LogItemViewModel
	{
		public Guid Id { get; set; }

		public LogType LogType { get; set; }

		public string CommandName { get; set; }

		public Guid CommandUniqueId { get; set; }

		public string EventName { get; set; }

		public bool IsSuccess { get; set; }

		public string Message { get; set; }

		public string Data { get; set; }

		public DateTime CreatedOn { get; set; }
	}

	public enum LogType
	{
		Info,
		Warning,
		Error
	}
}