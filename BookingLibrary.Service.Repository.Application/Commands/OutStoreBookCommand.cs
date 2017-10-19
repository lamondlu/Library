using System;
using BookingLibrary.Domain.Core.Commands;

namespace BookingLibrary.Service.Repository.Application.Commands
{
    public class OuttoreBookCommand : CommonCommand
    {
        private static string OutStoreBookCommandKey = "Command_OutStoreBook";

        public OuttoreBookCommand() : base(OutStoreBookCommandKey)
        {

        }

        public Guid BookId { get; set; }
    }
}