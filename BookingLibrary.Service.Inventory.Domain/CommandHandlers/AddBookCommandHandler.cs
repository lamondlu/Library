using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Service.Inventory.Domain.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Inventory.Domain;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Domain.Core.Messaging;

namespace BookingLibrary.Service.Inventory.Domain.CommandHandlers
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