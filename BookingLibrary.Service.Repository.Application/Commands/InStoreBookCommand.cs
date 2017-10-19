using System;
using BookingLibrary.Domain.Core.Commands;

namespace BookingLibrary.Service.Repository.Application.Commands
{
    public class InStoreBookCommand : CommonCommand
    {
        private static string InStoreBookCommandKey = "Command_InStoreBook";

        public InStoreBookCommand() : base(InStoreBookCommandKey)
        {

        }

        public Guid BookId { get; set; }
    }
}