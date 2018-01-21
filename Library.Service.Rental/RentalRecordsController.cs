using Library.Domain.Core.Messaging;
using Library.Infrastructure.InjectionFramework;
using Library.Service.Rental.Domain;
using Library.Service.Rental.Domain.Commands;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.ViewModels;
using Library.Service.Rental.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.Service.Rental
{
	[Route("api/customers/{customerId}/books")]
	public class RentalRecordsController : Controller
	{
		private ICommandPublisher _commandPublisher = null;

		private IRentalReportDataAccessor _reportDatabase = null;

		public RentalRecordsController(ICommandPublisher commandPubliser)
		{
			_commandPublisher = commandPubliser;
			_reportDatabase = InjectContainer.GetInstance<IRentalReportDataAccessor>();
		}

		[HttpPost("")]
		public Guid Rent(int customerId, [FromBody]RentBookDTO dto)
		{
			var command = new RentBookCommand
			{
				BookId = dto.BookId,
				BookName = dto.BookName,
				ISBN = dto.ISBN,
				Name = dto.Name,
				CustomerId = dto.CustomerId
			};

			_commandPublisher.Publish(command);

			return command.CommandUniqueId;
		}

		[HttpDelete("{bookId}")]
		public Guid Return(Guid customerId, Guid bookId)
		{
			var command = new ReturnBookCommand
			{
				BookId = bookId,
				CustomerId = customerId
			};

			_commandPublisher.Publish(command);
			return command.CommandUniqueId;
		}

		[HttpGet("~/api/unreturned_books")]
		public List<UnreturnedBookViewModel> GetAllUnreturnBooks()
		{
			return _reportDatabase.GetUnreturnBooks();
		}
	}
}