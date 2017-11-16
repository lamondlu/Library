using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Rental.Domain.DataAccessors;
using BookingLibrary.Service.Rental.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core.Messaging;

namespace BookingLibrary.Service.Rental.Domain.EventHandlers
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