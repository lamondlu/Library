using Library.Domain.Core;
using Library.Domain.Core.Commands;
using System;

namespace Library.Service.Rental.Domain
{
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