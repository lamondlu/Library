using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Library.Service.Inventory.Domain
{
    [CommandLog(Code = "NO_INVENTORY", Message = "No inventory.", Type = LogType.Warning)]
    [CommandLog(Code = "IMPORTED_COMPLETED", Message = "Command Finished.", Type = LogType.Info)]
    [CommandLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    public class ImportBookInventoryCommand : CommonCommand
    {
        private static string ImportBookInventoryCommandKey = "Command_ImportBookInventory";

        public ImportBookInventoryCommand() : base(ImportBookInventoryCommandKey)
        {
        }

        public Guid BookId { get; set; }

        public List<Guid> BookInventoryIds { get; set; }
    }
}