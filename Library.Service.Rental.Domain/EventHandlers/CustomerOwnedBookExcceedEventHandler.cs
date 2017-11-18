using Library.Domain.Core;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.Events;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class CustomerOwnedBookExcceedEventHandler : IEventHandler<CustomerOwnedBookExcceedEvent>
    {
        private ICommandTracker _commandTracker = null;

        public CustomerOwnedBookExcceedEventHandler(ICommandTracker commandTracker)
        {
            _commandTracker = commandTracker;
        }

        public void Handle(CustomerOwnedBookExcceedEvent evt)
        {
            try
            {
                _commandTracker.DirectError(evt.CommandUniqueId, "Error_CustomerOwnedBookExcceed", "One customer can only have 3 books at most.");
            }
            catch
            {
            }
        }

        public Task HandleAsync(CustomerOwnedBookExcceedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}