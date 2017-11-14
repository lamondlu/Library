using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Service.Inventory.Domain.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Inventory.Domain;

namespace BookingLibrary.Service.Inventory.Domain.CommandHandlers
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