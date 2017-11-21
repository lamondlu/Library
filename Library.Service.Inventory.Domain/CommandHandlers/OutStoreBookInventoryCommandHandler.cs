using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.Commands;
using System;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
    public class OutStoreBookInventoryCommandHandler : ICommandHandler<OutStoreBookInventoryCommand>
    {
        private IDomainRepository _domainRepository = null;
        private ILogger _logger = null;

        public OutStoreBookInventoryCommandHandler(IDomainRepository domainRepository, ILogger logger)
        {
            _domainRepository = domainRepository;
            _logger = logger;
        }

        public void Execute(OutStoreBookInventoryCommand command)
        {
            try
            {
                var bookInventory = _domainRepository.GetById<BookInventory>(command.BookInventoryId);

                bookInventory.OutStore(command.Notes);
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