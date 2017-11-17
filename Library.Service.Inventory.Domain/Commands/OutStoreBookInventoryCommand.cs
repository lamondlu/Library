using System;
using  Library.Domain.Core.Commands;

namespace  Library.Service.Inventory.Domain.Commands
{
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