using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core.Commands;

namespace BookingLibrary.Service.Inventory.Domain
{
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