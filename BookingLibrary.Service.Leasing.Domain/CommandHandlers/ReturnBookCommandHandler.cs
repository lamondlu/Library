using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Leasing.Domain.Commands;
using BookingLibrary.Service.Leasing.Domain.DataAccessors;

namespace BookingLibrary.Service.Leasing.Domain.CommandHandlers
{
    public class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand>
    {
        private IDomainRepository _domainRepository = null;
        private ILeasingReportDataAccessor _dataAccessor = null;

        public ReturnBookCommandHandler(IDomainRepository domainRepository, ILeasingReportDataAccessor dataAccesor)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
        }

        public void Dispose()
        {
            _domainRepository = null;
        }

        public void Execute(ReturnBookCommand command)
        {
            Customer customer = _domainRepository.GetById<Customer>(command.CustomerId);
            customer.ReturnBook(command.BookId);

            _domainRepository.Save(customer, customer.Version, command.CommandUniqueId);
        }
    }
}