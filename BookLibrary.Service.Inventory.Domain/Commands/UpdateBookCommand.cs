using System;
using BookLibrary.Domain.Core.Commands;

namespace BookLibrary.Service.Inventory.Domain.Commands
{
    public class UpdateBookCommand : CommonCommand
    {
        private static string UpdateBookCommandKey = "Command_UpdateBook";

        public UpdateBookCommand() : base(UpdateBookCommandKey)
        {

        }

        public Guid BookId { get; set; }

        public string BookName { get; set; }

        public string ISBN { get; set; }

        public DateTime DateIssued { get; set; }

        public string Description { get; set; }
    }
}