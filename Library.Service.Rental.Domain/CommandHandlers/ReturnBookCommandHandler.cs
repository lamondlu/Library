using System;
using  Library.Domain.Core.Commands;
using  Library.Domain.Core.DataAccessor;
using  Library.Service.Rental.Domain.Commands;
using  Library.Service.Rental.Domain.DataAccessors;

namespace  Library.Service.Rental.Domain.CommandHandlers
{
    public class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand>
    {
        private IDomainRepository _domainRepository = null;
        private IRentalReportDataAccessor _dataAccessor = null;

        public ReturnBookCommandHandler(IDomainRepository domainRepository, IRentalReportDataAccessor dataAccesor)
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