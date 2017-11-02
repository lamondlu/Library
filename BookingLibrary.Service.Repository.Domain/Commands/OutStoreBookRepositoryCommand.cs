using System;
using BookingLibrary.Domain.Core.Commands;

namespace BookingLibrary.Service.Repository.Domain.Commands
{
    public class OutStoreBookRepositoryCommand : CommonCommand
    {
        private static string OutStoreBookRepositoryCommandKey = "Command_OutStoreRepositoryBook";

        public OutStoreBookRepositoryCommand() : base(OutStoreBookRepositoryCommandKey)
        {

        }

        public Guid BookId { get; set; }

        public Guid BookRepositoryId { get; set; }

        public string Notes { get; set; }
    }
}