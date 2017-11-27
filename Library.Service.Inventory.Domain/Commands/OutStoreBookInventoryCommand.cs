using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Commands
{
    [CommandLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    [CommandLog(Code = "OUTSTORE_COMPLETED", Message = "Command finished.", Type = LogType.Info)]
    public class OutStoreBookInventoryCommand : CommonCommand
    {
        private static string OutStoreBookInventoryCommandKey = "Command_OutStoreInventoryBook";

        public OutStoreBookInventoryCommand() : base(OutStoreBookInventoryCommandKey)
        {
        }

        public Guid BookInventoryId { get; set; }

        public string Notes { get; set; }
    }
}