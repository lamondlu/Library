using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Commands
{
    [CommandLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    [CommandLog(Code = "INSTORE_COMPLETED", Message = "Command finished.", Type = LogType.Info)]
    public class InStoreBookInventoryCommand : CommonCommand
    {
        private static string InStoreBookInventoryCommandKey = "Command_InStoreBookInventory";

        public InStoreBookInventoryCommand() : base(InStoreBookInventoryCommandKey)
        {
        }

        public Guid BookId { get; set; }

        public Guid BookInventoryId { get; set; }

        public string Notes { get; set; }
    }
}