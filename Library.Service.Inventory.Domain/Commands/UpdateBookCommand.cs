using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Commands
{
    [CommandLog(Code = "BOOK_UPDATED", Message = "Command finished.", Type = LogType.Info)]
    [CommandLog(Code = "SERVER_ERROR", Type = LogType.Error)]
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