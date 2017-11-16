using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Rental.Domain.DataAccessors;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Service.Rental.Domain.Events;

namespace BookingLibrary.Service.Rental.Domain
{
    public class RentBookCommandHandler : ICommandHandler<RentBookCommand>
    {
        private IDomainRepository _domainRepository = null;
        private IRentalReportDataAccessor _dataAccessor = null;
        private IEventPublisher _eventPublisher = null;

        public RentBookCommandHandler(IDomainRepository domainRepository, IRentalReportDataAccessor dataAccesor, IEventPublisher eventPublisher)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
            _eventPublisher = eventPublisher;
        }

        public void Dispose()
        {
            _domainRepository = null;
        }

        public void Execute(RentBookCommand command)
        {
            Customer customer = null;

            if (_dataAccessor.IsNewCustomer(command.CustomerId))
            {
                customer = new Customer(command.CustomerId, command.Name);
            }
            else
            {
                customer = _domainRepository.GetById<Customer>(command.CustomerId);
            }

            if (customer.Books.Count == 3)
            {
                _eventPublisher.Publish(new CustomerOwnedBookExcceedEvent { CommandUniqueId = command.CommandUniqueId });
            }
            else
            {
                _eventPublisher.Publish(new RentBookRequestCreatedEvent
                {
                    ISBN = command.ISBN,
                    BookName = command.BookName,
                    BookInventoryId = command.BookId,
                    RentDate = DateTime.Now,
                    Name = customer.Name,
                    CommandUniqueId = command.CommandUniqueId
                });
            }
        }
    }
}