using Library.Domain.Core;
using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
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

        public override void ExecuteCore(AddBookCommand command)
        {
            try
            {
                var hasDuplicatedISBN = _dataAccessor.ExistISBN(command.ISBN);
                if (hasDuplicatedISBN)
                {
                    command.Result(AddBookCommand.Code_ADDBOOK_EXISTED);
                }
                else
                {
                    var book = new Book(command.BookId, command.ISBN, command.BookName, command.Description, command.DateIssued);
                    _domainRepository.Save(book, -1, command.CommandUniqueId);

                    command.Result(AddBookCommand.Code_ADDBOOK_COMPLETED);
                }
            }
            catch (Exception ex)
            {
                command.Result(CommonCommand.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}