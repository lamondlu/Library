using Library.Domain.Core;
using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.CommandHandlers;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain
{
	public class RentBookCommandHandler : BaseRentalCommandHandler<RentBookCommand>
	{
		private IIdentityCrossServiceDataAccessor _identityDataAccessor = null;

		public RentBookCommandHandler(IDomainRepository domainRepository, IRentalReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger, IEventPublisher eventPublisher, IIdentityCrossServiceDataAccessor identityDataAccessor) : base(domainRepository, dataAccesor, tracker, logger, eventPublisher)
		{
			_identityDataAccessor = identityDataAccessor;
		}

		public override void ExecuteCore(RentBookCommand command)
		{
			try
			{
				var customer = _identityDataAccessor.GetCustomerDetails(command.CustomerId);

				_eventPublisher.Publish(new RentBookRequestCreatedEvent
				{
					ISBN = command.ISBN,
					BookName = command.BookName,
					BookInventoryId = command.BookId,
					RentDate = DateTime.Now,
					Name = new PersonName(customer.FirstName, customer.MiddleName, customer.LastName),
					CommandUniqueId = command.CommandUniqueId,
					AggregateId = command.CustomerId
				});

				command.Result(RentBookCommand.Code_BOOK_RENTED);
			}
			catch (Exception ex)
			{
				command.Result(CommonCommand.Code_SERVER_ERROR, ex.ToString());
			}
		}
	}
}