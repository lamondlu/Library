using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Rental.Domain.Commands
{
    [CommandLog(Code = "BOOK_RETURNED", Message = "Command Finished.", Type = LogType.Info)]
    [CommandLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    public class ReturnBookCommand : CommonCommand
    {
        private static string Command_ReturnBook = "Command_ReturnBook";

        public ReturnBookCommand() : base(Command_ReturnBook)
        {
        }

        public Guid CustomerId { get; set; }

        public Guid BookId { get; set; }
    }
}