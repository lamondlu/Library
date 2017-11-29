using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Commands
{
    [CommandLog(Code = "ADDBOOK_EXISTED", Message = "The book has existed in the system.", Type = LogType.Warning, SendError = true)]
    [CommandLog(Code = "SERVER_ERROR", Type = LogType.Error, SendError = true)]
    [CommandLog(Code = "ADDBOOK_COMPLETED", Message = "Command Finished.", Type = LogType.Info)]
    public class AddBookCommand : CommonCommand
    {
        private static string AddBookCommandKey = "Command_AddBook";

        public AddBookCommand() : base(AddBookCommandKey)
        {
        }

        public Guid BookId { get; set; }

        public string BookName { get; set; }

        public string ISBN { get; set; }

        public DateTime DateIssued { get; set; }

        public string Description { get; set; }
    }
}