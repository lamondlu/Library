using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Service.Repository.Domain.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Repository.Domain;

namespace BookingLibrary.Service.Repository.Domain.CommandHandlers
{
    public class OutStoreBookRepositoryCommandHandler : ICommandHandler<OutStoreBookRepositoryCommand>
    {
        private IDomainRepository _domainRepository = null;

        public OutStoreBookRepositoryCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Execute(OutStoreBookRepositoryCommand command)
        {
            var book = _domainRepository.GetById<Book>(command.BookId);

            book.OutStoreBookRepository(command.BookRepositoryId, command.Notes);
            _domainRepository.Save(book, book.Version, command.CommandUniqueId);
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}