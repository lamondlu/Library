using Library.Domain.Core;

namespace Library.Service.Rental.Domain.Events
{
    public class CustomerOwnedBookExcceedEvent : DomainEvent
    {
        private static string EVENT_CustomerOwnedBookExcceed = "Event_CustomerOwnedBookExcceed";

        public CustomerOwnedBookExcceedEvent() : base(EVENT_CustomerOwnedBookExcceed)
        {
        }
    }
}