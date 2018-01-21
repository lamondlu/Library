using Library.Domain.Core;
using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.Commands;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain.CommandHandlers
{
	public class ReturnBookCommandHandler : BaseRentalCommandHandler<ReturnBookCommand>
	{
		public ReturnBookCommandHandler(IDomainRepository domainRepository, IRentalReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger, IEventPublisher eventPublisher) : base(domainRepository, dataAccesor, tracker, logger, eventPublisher)
		{
		}

		public override void ExecuteCore(ReturnBookCommand command)
		{
			try
			{
				Customer customer = _domainRepository.GetById<Customer>(command.CustomerId);

				_eventPublisher.Publish(new ReturnBookRequestCreatedEvent
				{
					BookInventoryId = command.BookId,
					ReturnDate = DateTime.Now,
					Name = customer.Name,
					CommandUniqueId = command.CommandUniqueId,
					AggregateId = command.CustomerId
				});

				command.Result(ReturnBookCommand.Code_BOOK_RETURNED);
			}
			catch (Exception ex)
			{
				command.Result(CommonCommand.Code_SERVER_ERROR, ex.ToString());
			}
		}
	}
}