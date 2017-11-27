using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Rental.Domain
{
    [CommandLog(Code = "OWNED_BOOK_EXCCEED", Message = "One customer can only have 3 book at most.", Type = LogType.Warning)]
    [CommandLog(Code = "BOOK_RENTED", Message = "Command Finished.", Type = LogType.Info)]
    [CommandLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    public class RentBookCommand : CommonCommand
    {
        private static string Command_RentBook = "Command_RentBook";

        public RentBookCommand() : base(Command_RentBook)
        {
        }

        public Guid BookId { get; set; }

        public string BookName { get; set; }

        public string ISBN { get; set; }

        public Guid CustomerId { get; set; }

        public PersonName Name { get; set; }
    }
}