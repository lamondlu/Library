using Library.Domain.Core;

namespace Library.Service.Identity.Domain
{
	public class AdministratorCreatedEvent : DomainEvent
	{
		private readonly static string Event_AdministratorCreated = "Event_AdministratorCreated";

		public AdministratorCreatedEvent() : base(Event_AdministratorCreated)
		{
		}

		public UserPrincipal Principal { get; set; }

		public PersonName PersonName { get; set; }
	}
}