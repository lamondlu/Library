using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.Commands;
using Library.Service.Inventory.Domain.DataAccessors;
using System;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private IDomainRepository _domainRepository = null;
        private IInventoryReportDataAccessor _dataAccessor = null;
        private ICommandTracker _tracker = null;
        private ILogger _logger = null;

        public AddBookCommandHandler(IDomainRepository domainRepository, IInventoryReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
            _tracker = tracker;
            _logger = logger;
        }

        public void Execute(AddBookCommand command)
        {
            try
            {
                var hasDuplicatedISBN = _dataAccessor.ExistISBN(command.ISBN);
                if (hasDuplicatedISBN)
                {
                    //Record down the error and use signalR to transfer the error.

                    _tracker.Error(command.CommandUniqueId, string.Empty, "ADDBOOK_EXISTED", "The book has existed in the system.");
                    _logger.Error(command.CommandUniqueId, command.CommandKey, string.Empty, "ADDBOOK_EXISTED:The book has existed in the system.", command);
                }
                else
                {
                    var book = new Book(command.BookId, command.ISBN, command.BookName, command.Description, command.DateIssued);
                    _domainRepository.Save(book, -1, command.CommandUniqueId);

                    _logger.Success(command.CommandUniqueId, command.CommandKey, string.Empty, string.Empty, command);
                }
            }
            catch (Exception ex)
            {
                _tracker.Error(command.CommandUniqueId, string.Empty, "SERVER_ERROR", ex.ToString());
            }
        }

        public void Dispose()
        {
            _domainRepository = null;
        }
    }
}