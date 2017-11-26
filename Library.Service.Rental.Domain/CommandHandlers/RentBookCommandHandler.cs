using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.CommandHandlers;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain
{
    public class RentBookCommandHandler : BaseRentalCommandHandler<RentBookCommand>
    {
        public RentBookCommandHandler(IDomainRepository domainRepository, IRentalReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger, IEventPublisher eventPublisher) : base(domainRepository, dataAccesor, tracker, logger, eventPublisher)
        {
        }

        public override void Execute(RentBookCommand command)
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