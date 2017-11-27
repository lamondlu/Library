using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Domain.Core.Models;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.Commands;
using Library.Service.Inventory.Domain.DataAccessors;
using System;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
    public class OutStoreBookInventoryCommandHandler : BaseInventoryCommandHandler<OutStoreBookInventoryCommand>
    {
        public OutStoreBookInventoryCommandHandler(DomainRepository domainRepository, IInventoryReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger) : base(domainRepository, dataAccesor, tracker, logger)
        {
        }

        
        public override void Execute(OutStoreBookInventoryCommand command)
        {
            try
            {
                var bookInventory = _domainRepository.GetById<BookInventory>(command.BookInventoryId);

                bookInventory.OutStore(command.Notes);
                _domainRepository.Save(bookInventory, bookInventory.Version, command.CommandUniqueId);

                AddCommandLog(command, "OUTSTORE_COMPLETED");
            }
            catch (Exception ex)
            {
                AddCommandLog(command, "SERVER_ERROR", ex.ToString());
            }
        }
    }
}