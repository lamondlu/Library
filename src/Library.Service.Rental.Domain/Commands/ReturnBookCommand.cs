using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Rental.Domain.Commands
{
    [CommandLog(Code = Code_BOOK_RETURNED, Message = "Command Finished.", Type = LogType.Info)]
    [CommandLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
    public class ReturnBookCommand : CommonCommand
    {
        private static string Command_ReturnBook = "Command_ReturnBook";
        public const string Code_BOOK_RETURNED = "BOOK_RETURNED";

        public ReturnBookCommand() : base(Command_ReturnBook)
        {
        }

        public Guid CustomerId { get; set; }

        public Guid BookId { get; set; }
    }
}