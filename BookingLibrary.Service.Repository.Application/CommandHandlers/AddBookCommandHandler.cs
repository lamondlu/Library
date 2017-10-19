using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Service.Repository.Application.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Repository.Domain;

namespace BookingLibrary.Service.Repository.Application.CommandHandlers
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private IDomainRepository _domainRepository = null;

        public AddBookCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Execute(AddBookCommand command)
        {
            var book = new Book(command.BookId, command.BookName, command.ISBN, command.Description, command.DateIssued);
            //_domainRepository.Save(book, 1);
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}