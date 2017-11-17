using System;
using System.ComponentModel.DataAnnotations;
using  Library.Service.Inventory.Domain;

namespace  Library.Service.Inventory.DTOs
{
    public class ChangeBookStatusDTO
    {
        public BookInventoryStatus Status { get; set; }

        public string Notes { get; set; }
    }
}