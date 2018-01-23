using Library.Domain.Core.Models;
using System;

namespace Library.Domain.Core.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class EventLogAttribute : Attribute
	{
		public string Code { get; set; }

		public string Message { get; set; }

		public LogType Type { get; set; }

		public bool SendFinish { get; set; }

		public bool SendError { get; set; }
	}
}