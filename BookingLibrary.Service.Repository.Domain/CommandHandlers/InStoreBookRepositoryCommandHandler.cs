using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Service.Repository.Domain.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Repository.Domain;

namespace BookingLibrary.Service.Repository.Domain.CommandHandlers
{
    public class InStoreBookRepositoryCommandHandler : ICommandHandler<InStoreBookRepositoryCommand>
    {
        private IDomainRepository _domainRepository = null;

        public InStoreBookRepositoryCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Execute(InStoreBookRepositoryCommand command)
        {
            var book = _domainRepository.GetById<Book>(command.BookId);

            book.InStoreBookRepository(command.BookRepositoryId, command.Notes);
            _domainRepository.Save(book, book.Version, command.CommandUniqueId);
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}