using Library.Domain.Core.Commands;
using System;

namespace Library.Service.Inventory.Domain.Commands
{
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