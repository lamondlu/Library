using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.Commands;
using Library.Service.Inventory.Domain.DataAccessors;
using System;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
    public class AddBookCommandHandler : BaseInventoryCommandHandler<AddBookCommand>
    {
        public AddBookCommandHandler(IDomainRepository domainRepository, IInventoryReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger) : base(domainRepository, dataAccesor, tracker, logger)
        {

        }

        public override void Execute(AddBookCommand command)
        {
            try
            {
                var hasDuplicatedISBN = _dataAccessor.ExistISBN(command.ISBN);
                if (hasDuplicatedISBN)
                {
                    //Record down the error and use signalR to transfer the error.

                    _tracker.Error(command.CommandUniqueId, string.Empty, "ADDBOOK_EXISTED", "The book has existed in the system.");
                    _logger.CommandWarning(command, "ADDBOOK_EXISTED:The book has existed in the system.");
                }
                else
                {
                    var book = new Book(command.BookId, command.ISBN, command.BookName, command.Description, command.DateIssued);
                    _domainRepository.Save(book, -1, command.CommandUniqueId);

                    _logger.CommandInfo(command, "Command Finished.");
                }
            }
            catch (Exception ex)
            {
                _tracker.Error(command.CommandUniqueId, string.Empty, "SERVER_ERROR", ex.ToString());
                _logger.CommandError(command, $"SERVER_ERROR:{ex.ToString()}");
            }
        }
    }
}