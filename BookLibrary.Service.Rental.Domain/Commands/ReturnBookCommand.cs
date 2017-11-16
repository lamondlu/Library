using System;
using BookLibrary.Domain.Core.Commands;

namespace BookLibrary.Service.Rental.Domain.Commands
{
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