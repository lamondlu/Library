using Library.Domain.Core;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class CustomerOwnedBookExcceedEventHandler : IEventHandler<CustomerOwnedBookExcceedEvent>
    {
        private ICommandTracker _commandTracker = null;
        private ILogger _logger = null;

        public CustomerOwnedBookExcceedEventHandler(ICommandTracker commandTracker, ILogger logger)
        {
            _commandTracker = commandTracker;
            _logger = logger;
        }

        public void Handle(CustomerOwnedBookExcceedEvent evt)
        {
            try
            {
                _commandTracker.DirectError(evt.CommandUniqueId, "Error_CustomerOwnedBookExcceed", "One customer can only have 3 books at most.");
                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
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