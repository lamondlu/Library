using System;
using System.ComponentModel.DataAnnotations;
using BookLibrary.Service.Inventory.Domain;

namespace BookLibrary.Service.Inventory.DTOs
{
    public class ChangeBookStatusDTO
    {
        public BookInventoryStatus Status { get; set; }

        public string Notes { get; set; }
    }
}