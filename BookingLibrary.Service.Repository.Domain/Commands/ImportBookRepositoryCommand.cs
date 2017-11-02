using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core.Commands;

namespace BookingLibrary.Service.Repository.Domain
{
    public class ImportBookRepositoryCommand : CommonCommand
    {
        private static string ImportBookRepositoryCommandKey = "Command_ImportBookRepository";

        public ImportBookRepositoryCommand() : base(ImportBookRepositoryCommandKey)
        {

        }

        public Guid BookId { get; set; }

        public List<Guid> BookRepositoryIds { get; set; }
    }
}