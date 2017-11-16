using System;
using System.Collections.Generic;

namespace BookLibrary.Service.Inventory.DTOs
{
    public class ImportBookInventoryDTO
    {
        public List<Guid> BookInventoryIds { get; set; }
    }
}