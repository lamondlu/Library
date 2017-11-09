using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Service.Repository.Domain.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Repository.Domain;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Domain.Core.Messaging;

namespace BookingLibrary.Service.Repository.Domain.CommandHandlers
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private IDomainRepository _domainRepository = null;
        private IRepositoryReportDataAccessor _dataAccessor = null;
        private ICommandTracker _tracker = null;

        public AddBookCommandHandler(IDomainRepository domainRepository, IRepositoryReportDataAccessor dataAccesor, ICommandTracker tracker)
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

                _tracker.Error(command.CommandUniqueId, string.Empty, "100001", "The book has existed in the system.");
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