using System;
using BookingLibrary.Domain.Core.Commands;

namespace BookingLibrary.Service.Inventory.Domain.Commands
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