using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Library.Service.Inventory.Domain
{
    [CommandLog(Code = Code_NO_INVENTORY, Message = "No inventory.", Type = LogType.Warning, SendError = true)]
    [CommandLog(Code = Code_IMPORTED_COMPLETED, Message = "Command Finished.", Type = LogType.Info)]
    [CommandLog(Code = Code_SERVER_ERROR, Type = LogType.Error, SendError = true)]
    public class ImportBookInventoryCommand : CommonCommand
    {
        private static string ImportBookInventoryCommandKey = "Command_ImportBookInventory";
        public const string Code_NO_INVENTORY = "NO_INVENTORY";
        public const string Code_IMPORTED_COMPLETED = "IMPORTED_COMPLETED";

        public ImportBookInventoryCommand() : base(ImportBookInventoryCommandKey)
        {
        }

        public Guid BookId { get; set; }

        public List<Guid> BookInventoryIds { get; set; }
    }
}