using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.Commands;
using System;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
    public class InStoreBookInventoryCommandHandler : ICommandHandler<InStoreBookInventoryCommand>
    {
        private IDomainRepository _domainRepository = null;
        private ILogger _logger = null;

        public InStoreBookInventoryCommandHandler(IDomainRepository domainRepository, ILogger logger)
        {
            _domainRepository = domainRepository;
            _logger = logger;
        }

        public void Execute(InStoreBookInventoryCommand command)
        {
            try
            {
                var bookInventory = _domainRepository.GetById<BookInventory>(command.BookInventoryId);
                bookInventory.InStore(command.Notes);
                _domainRepository.Save(bookInventory, bookInventory.Version, command.CommandUniqueId);

                _logger.CommandInfo(command, "Command finished.");
            }
            catch (Exception ex)
            {
                _logger.CommandError(command, $"SERVER_ERROR:{ex.ToString()}");
            }
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}