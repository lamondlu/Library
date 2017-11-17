using System;
using  Library.Domain.Core.Commands;
using  Library.Service.Inventory.Domain.Commands;
using  Library.Domain.Core.DataAccessor;
using  Library.Service.Inventory.Domain;

namespace  Library.Service.Inventory.Domain.CommandHandlers
{
    public class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand>
    {
        private IDomainRepository _domainRepository = null;

        public UpdateBookCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Execute(UpdateBookCommand command)
        {
            var book = _domainRepository.GetById<Book>(command.BookId);

            if (book.BookName != command.BookName)
            {
                book.ChangeBookName(command.BookName);
            }

            if (book.ISBN != command.ISBN)
            {
                book.ChangeISBN(command.ISBN);
            }

            if (book.Description != command.Description)
            {
                book.ChangeDescription(command.Description);
            }

            if (book.DateIssued != command.DateIssued)
            {
                book.ChangeIssuedDate(command.DateIssued);
            }

            _domainRepository.Save(book, book.Version, command.CommandUniqueId);
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}