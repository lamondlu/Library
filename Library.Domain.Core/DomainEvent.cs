using System;

namespace Library.Domain.Core
{
	public abstract class DomainEvent : IDomainEvent
	{
		public const string Code_SERVER_ERROR = "SERVER_ERROR";
		private string _eventKey = string.Empty;
		private string _eventResult = string.Empty;
		private string _extraMessage = string.Empty;

		private DateTime _occurredOn;

		public DomainEvent(string eventKey)
		{
			_occurredOn = DateTime.Now;
			_eventKey = eventKey;
		}

		public string EventKey
		{
			get
			{
				return _eventKey;
			}
		}

		public int Version
		{
			get;
			set;
		}

		public Guid AggregateId
		{
			get;
			set;
		}

		public Guid CommandUniqueId
		{
			get;
			set;
		}

		public DateTime OccurredOn
		{
			get
			{
				return _occurredOn;
			}
		}

		public void Result(string code, string extraMessage = "")
		{
			_eventResult = code;
			_extraMessage = extraMessage;
		}

		public string EventResult
		{
			get
			{
				return _eventResult;
			}
		}

		public string ExtraMessage
		{
			get
			{
				return _extraMessage;
			}
		}
	}
}