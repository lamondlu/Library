using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Service.Repository.Application.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Repository.Domain;

namespace BookingLibrary.Service.Repository.Application.CommandHandlers
{
    public class InStoreBookCommandHandler : ICommandHandler<InStoreBookCommand>
    {
        private IDomainRepository _domainRepository = null;

        public InStoreBookCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Execute(InStoreBookCommand command)
        {
            var book = _domainRepository.GetById<Book>(command.BookId);

            book.InStore();
            _domainRepository.Save(book, book.Version);
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}