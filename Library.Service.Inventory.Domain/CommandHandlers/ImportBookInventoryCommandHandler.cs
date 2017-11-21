using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;

namespace Library.Service.Inventory.Domain
{
    public class ImportBookInventoryCommandHandler : ICommandHandler<ImportBookInventoryCommand>
    {
        private IDomainRepository _domainRepository = null;
        private ICommandTracker _tracker = null;

        private ILogger _logger = null;

        public ImportBookInventoryCommandHandler(IDomainRepository domainRepository, ICommandTracker tracker, ILogger logger)
        {
            _domainRepository = domainRepository;
            _tracker = tracker;
            _logger = logger;
        }

        public void Dispose()
        {
            _domainRepository = null;
        }

        public void Execute(ImportBookInventoryCommand command)
        {
            try
            {
                if (command.BookInventoryIds == null || command.BookInventoryIds.Count == 0)
                {
                    _tracker.Error(command.CommandUniqueId, string.Empty, "NO_INVENTORY", "No inventory.");
                }

                foreach (var id in command.BookInventoryIds)
                {
                    var bookInventory = new BookInventory(id, command.BookId, "Bulk Imported");
                    _domainRepository.Save(bookInventory, -1, command.CommandUniqueId);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}