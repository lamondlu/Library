using System;
using BookingLibrary.Domain.Core.Commands;

namespace BookingLibrary.Service.Repository.Domain.Commands
{
    public class OutStoreBookCommand : CommonCommand
    {
        private static string OutStoreBookCommandKey = "Command_OutStoreBook";

        public OutStoreBookCommand() : base(OutStoreBookCommandKey)
        {

        }

        public Guid BookId { get; set; }
    }
}