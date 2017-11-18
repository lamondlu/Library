using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.Commands;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain.CommandHandlers
{
    public class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand>
    {
        private IDomainRepository _domainRepository = null;
        private IRentalReportDataAccessor _dataAccessor = null;
        private IEventPublisher _eventPublisher = null;

        public ReturnBookCommandHandler(IDomainRepository domainRepository, IRentalReportDataAccessor dataAccesor, IEventPublisher eventPublisher)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
            _eventPublisher = eventPublisher;
        }

        public void Dispose()
        {
            _domainRepository = null;
        }

        public void Execute(ReturnBookCommand command)
        {
            Customer customer = _domainRepository.GetById<Customer>(command.CustomerId);

            _eventPublisher.Publish(new ReturnBookRequestCreatedEvent
            {
                BookInventoryId = command.BookId,
                ReturnDate = DateTime.Now,
                Name = customer.Name,
                CommandUniqueId = command.CommandUniqueId,
                AggregateId = command.CustomerId
            });
        }
    }
}