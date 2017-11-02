using System;
using BookingLibrary.Domain.Core.Commands;

namespace BookingLibrary.Service.Repository.Domain.Commands
{
    public class InStoreBookRepositoryCommand : CommonCommand
    {
        private static string InStoreBookRepositoryCommandKey = "Command_InStoreBookRepository";

        public InStoreBookRepositoryCommand() : base(InStoreBookRepositoryCommandKey)
        {

        }

        public Guid BookId { get; set; }

        public Guid BookRepositoryId { get; set; }

        public string Notes { get; set; }
    }
}