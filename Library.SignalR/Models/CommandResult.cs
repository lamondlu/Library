using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.SignalR.Models
{
	public class CommandResult
	{
		public CommandResult()
		{
			EventResults = new List<EventResult>();
		}

		public Guid CommandUniqueId { get; set; }

		public string ConnectionId { get; set; }

		public List<EventResult> EventResults { get; set; }

		public bool IsFinished
		{
			get
			{
				return EventResults.Count != 0 && EventResults.All(p => p.IsFinished);
			}
		}

		public bool IsError
		{
			get
			{
				return EventResults.Any(p => p.IsError);
			}
		}
	}
}