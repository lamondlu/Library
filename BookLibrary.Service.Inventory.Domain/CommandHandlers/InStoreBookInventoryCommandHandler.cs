using System;
using BookLibrary.Domain.Core.Commands;
using BookLibrary.Service.Inventory.Domain.Commands;
using BookLibrary.Domain.Core.DataAccessor;
using BookLibrary.Service.Inventory.Domain;

namespace BookLibrary.Service.Inventory.Domain.CommandHandlers
{
    public class InStoreBookInventoryCommandHandler : ICommandHandler<InStoreBookInventoryCommand>
    {
        private IDomainRepository _domainRepository = null;

        public InStoreBookInventoryCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Execute(InStoreBookInventoryCommand command)
        {
            var bookInventory = _domainRepository.GetById<BookInventory>(command.BookInventoryId);
            bookInventory.InStore(command.Notes);
            _domainRepository.Save(bookInventory, bookInventory.Version, command.CommandUniqueId);
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}