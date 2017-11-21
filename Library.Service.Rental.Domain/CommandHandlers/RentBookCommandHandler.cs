using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain
{
    public class RentBookCommandHandler : ICommandHandler<RentBookCommand>
    {
        private IDomainRepository _domainRepository = null;
        private IRentalReportDataAccessor _dataAccessor = null;
        private IEventPublisher _eventPublisher = null;
        private ILogger _logger = null;

        public RentBookCommandHandler(IDomainRepository domainRepository, IRentalReportDataAccessor dataAccesor, IEventPublisher eventPublisher, ILogger logger)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
            _eventPublisher = eventPublisher;
            _logger = logger;
        }

        public void Dispose()
        {
            _domainRepository = null;
        }

        public void Execute(RentBookCommand command)
        {
            try
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
                    _logger.CommandWarning(command, "OWNED_BOOK_EXCCEED: One customer can only have 3 book at most.");
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

                    _logger.CommandInfo(command, "Command Finished.");
                }
            }
            catch (Exception ex)
            {
                _logger.CommandError(command, $"SERVER_ERROR: {ex.ToString()}");
            }
        }
    }
}