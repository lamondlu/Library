using System;
using BookLibrary.Domain.Core.Commands;
using BookLibrary.Domain.Core.DataAccessor;
using BookLibrary.Service.Rental.Domain.DataAccessors;
using BookLibrary.Domain.Core.Messaging;
using BookLibrary.Service.Rental.Domain.Events;

namespace BookLibrary.Service.Rental.Domain
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
                _domainRepository.Save(customer, -1, command.CommandUniqueId);
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
                    CommandUniqueId = command.CommandUniqueId,
                    AggregateId = command.CustomerId
                });
            }
        }
    }
}