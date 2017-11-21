using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.Commands;
using System;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
    public class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand>
    {
        private IDomainRepository _domainRepository = null;
        private ILogger _logger = null;

        public UpdateBookCommandHandler(IDomainRepository domainRepository, ILogger logger)
        {
            _domainRepository = domainRepository;
            _logger = logger;
        }

        public void Execute(UpdateBookCommand command)
        {
            try
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
                _logger.CommandInfo(command, "Command finished.");
            }
            catch (Exception ex)
            {
                _logger.CommandError(command, $"SERVER_ERROR:{ex.ToString()}");
            }
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}