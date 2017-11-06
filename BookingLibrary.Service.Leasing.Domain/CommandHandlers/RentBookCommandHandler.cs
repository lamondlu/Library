using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Repository.Domain.DataAccessors;

namespace BookingLibrary.Service.Leasing.Domain
{
    public class RentBookCommandHandler : ICommandHandler<RentBookCommand>
    {
        private IDomainRepository _domainRepository = null;
        private ILeasingReportDataAccessor _dataAccessor = null;

        public RentBookCommandHandler(IDomainRepository domainRepository, ILeasingReportDataAccessor dataAccesor)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
        }

        public void Dispose()
        {
            _domainRepository = null;
        }

        public void Execute(RentBookCommand command)
        {
            Customer customer = null;

            if (_dataAccessor.IsNewCustomer(command.CustomerId))
            {
                customer = new Customer(command.CustomerId, command.Name);
            }
            else
            {
                customer = _domainRepository.GetById<Customer>(command.CustomerId);
            }

            customer.RentBook(new Book
            {
                BookName = command.BookName,
                ISBN = command.ISBN,
                Id = command.BookId
            });
        }
    }
}