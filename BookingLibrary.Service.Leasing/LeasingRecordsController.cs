using System;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Infrastructure.InjectionFramework;
using BookingLibrary.Service.Leasing.Domain;
using BookingLibrary.Service.Leasing.Domain.DataAccessors;
using BookingLibrary.Service.Leasing.DTOs;
using Microsoft.AspNetCore.Mvc;
using BookingLibrary.Service.Leasing.Domain.Commands;
using BookingLibrary.Service.Leasing.Domain.ViewModels;
using System.Collections.Generic;

namespace BookingLibrary.Service.Leasing
{
    [Route("api/customers/{customerId}/books")]
    public class LeasingRecordsController : Controller
    {
        private ICommandPublisher _commandPublisher = null;
        private ILeasingReportDataAccessor _reportDatabase = null;

        public LeasingRecordsController()
        {
            _commandPublisher = InjectContainer.GetInstance<ICommandPublisher>();
            _reportDatabase = InjectContainer.GetInstance<ILeasingReportDataAccessor>();
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

        [HttpPut("")]
        public Guid Return(int customerId, [FromBody]ReturnBookDTO dto)
        {
            var command = new ReturnBookCommand
            {
                BookId = dto.BookId
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