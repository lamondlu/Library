using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.CommandHandlers;
using Library.Service.Inventory.Domain.DataAccessors;
using System;

namespace Library.Service.Inventory.Domain
{
    public class ImportBookInventoryCommandHandler : BaseInventoryCommandHandler<ImportBookInventoryCommand>
    {
        public ImportBookInventoryCommandHandler(IDomainRepository domainRepository, IInventoryReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger) : base(domainRepository, dataAccesor, tracker, logger)
        {
        }


        public override void Execute(ImportBookInventoryCommand command)
        {
            try
            {
                if (command.BookInventoryIds == null || command.BookInventoryIds.Count == 0)
                {
                    _tracker.Error(command.CommandUniqueId, string.Empty, "NO_INVENTORY", "No inventory.");
                    _logger.CommandWarning(command, "NO_INVENTORY: No Inventory.");
                    return;
                }

                foreach (var id in command.BookInventoryIds)
                {
                    var bookInventory = new BookInventory(id, command.BookId, "Bulk Imported");
                    _domainRepository.Save(bookInventory, -1, command.CommandUniqueId);
                }

                _logger.CommandInfo(command, "Command Finished.");
            }
            catch (Exception ex)
            {
                _tracker.Error(command.CommandUniqueId, string.Empty, "SERVER_ERROR", "SERVER_ERROR:" + ex.ToString());
                _logger.CommandInfo(command, "SERVER_ERROR:" + ex.ToString());
            }
        }
    }
}