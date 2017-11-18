using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.Commands;
using Library.Service.Inventory.Domain.DataAccessors;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private IDomainRepository _domainRepository = null;
        private IInventoryReportDataAccessor _dataAccessor = null;
        private ICommandTracker _tracker = null;

        public AddBookCommandHandler(IDomainRepository domainRepository, IInventoryReportDataAccessor dataAccesor, ICommandTracker tracker)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
            _tracker = tracker;
        }

        public void Execute(AddBookCommand command)
        {
            var hasDuplicatedISBN = _dataAccessor.ExistISBN(command.ISBN);

            if (hasDuplicatedISBN)
            {
                //Record down the error and use signalR to transfer the error.

                _tracker.Error(command.CommandUniqueId, string.Empty, "ADDBOOK_EXISTED", "The book has existed in the system.");
            }
            else
            {
                var book = new Book(command.BookId, command.ISBN, command.BookName, command.Description, command.DateIssued);

                _domainRepository.Save(book, -1, command.CommandUniqueId);
            }
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}