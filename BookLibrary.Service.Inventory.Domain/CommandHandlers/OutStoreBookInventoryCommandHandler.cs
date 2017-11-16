using System;
using BookLibrary.Domain.Core.Commands;
using BookLibrary.Service.Inventory.Domain.Commands;
using BookLibrary.Domain.Core.DataAccessor;
using BookLibrary.Service.Inventory.Domain;

namespace BookLibrary.Service.Inventory.Domain.CommandHandlers
{
    public class OutStoreBookInventoryCommandHandler : ICommandHandler<OutStoreBookInventoryCommand>
    {
        private IDomainRepository _domainRepository = null;

        public OutStoreBookInventoryCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Execute(OutStoreBookInventoryCommand command)
        {
            var bookInventory = _domainRepository.GetById<BookInventory>(command.BookInventoryId);

            bookInventory.OutStore(command.Notes);
            _domainRepository.Save(bookInventory, bookInventory.Version, command.CommandUniqueId);
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}