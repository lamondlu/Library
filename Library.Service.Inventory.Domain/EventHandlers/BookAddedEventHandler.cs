using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.DTOs;
using Library.Service.Inventory.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookAddedEventHandler : BaseInventoryEventHandler<BookAddedEvent>
    {
        public BookAddedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher):base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {

        }

        public override void Handle(BookAddedEvent evt)
        {
            try
            {
                _reportDataAccessor.AddBook(new AddBookDTO
                {
                    BookId = evt.AggregateId,
                    BookName = evt.BookName,
                    Description = evt.Description,
                    ISBN = evt.ISBN,
                    DateIssued = evt.DateIssued
                });

                _reportDataAccessor.Commit();
                _commandTracker.DirectFinish(evt.CommandUniqueId);
                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR:{ex.ToString()}");
            }
        }
    }
}