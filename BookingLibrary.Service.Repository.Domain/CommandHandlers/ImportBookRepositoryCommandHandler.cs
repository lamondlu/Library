using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Domain.Core.DataAccessor;

namespace BookingLibrary.Service.Repository.Domain
{
    public class ImportBookRepositoryCommandHandler : ICommandHandler<ImportBookRepositoryCommand>
    {
        private IDomainRepository _domainRepository = null;

        public ImportBookRepositoryCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Dispose()
        {
            _domainRepository = null;
        }

        public void Execute(ImportBookRepositoryCommand command)
        {
            var book = _domainRepository.GetById<Book>(command.BookId);
            book.Import(command.BookRepositoryIds);
            _domainRepository.Save(book, book.Version, command.CommandUniqueId);
        }
    }
}