using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
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

        public override void ExecuteCore(OutStoreBookInventoryCommand command)
        {
            try
            {
                var bookInventory = _domainRepository.GetById<BookInventory>(command.BookInventoryId);

                bookInventory.OutStore(command.Notes, command.OutStoreDate);
                _domainRepository.Save(bookInventory, bookInventory.Version, command.CommandUniqueId);

                command.Result(OutStoreBookInventoryCommand.Code_OUTSTORE_COMPLETED);
            }
            catch (Exception ex)
            {
                command.Result(OutStoreBookInventoryCommand.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}