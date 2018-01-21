using Library.Service.Inventory.Domain;
using System;

namespace Library.Service.Inventory.DTOs
{
	public class ChangeBookStatusDTO
	{
		public BookInventoryStatus Status { get; set; }

		public string Notes { get; set; }

		public DateTime OccurredDate { get; set; }
	}
}