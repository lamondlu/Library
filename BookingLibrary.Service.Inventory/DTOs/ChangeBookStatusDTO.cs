using System;
using System.ComponentModel.DataAnnotations;
using BookingLibrary.Service.Inventory.Domain;

namespace BookingLibrary.Service.Inventory.DTOs
{
    public class ChangeBookStatusDTO
    {
        public BookInventoryStatus Status { get; set; }

        public string Notes { get; set; }
    }
}