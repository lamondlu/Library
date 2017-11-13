using System;
using System.Collections.Generic;

namespace BookingLibrary.Service.Inventory.DTOs
{
    public class ImportBookInventoryDTO
    {
        public List<Guid> BookInventoryIds { get; set; }
    }
}