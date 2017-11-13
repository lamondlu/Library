using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Service.Inventory.Domain.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Inventory.Domain;

namespace BookingLibrary.Service.Inventory.Domain.CommandHandlers
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
            var book = _domainRepository.GetById<Book>(command.BookId);

            book.InStoreBookInventory(command.BookInventoryId, command.Notes);
            _domainRepository.Save(book, book.Version, command.CommandUniqueId);
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}