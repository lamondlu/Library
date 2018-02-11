using System;

namespace BookingLibrary.CoreUI.DTOs
{
	public class InStoreBookInventoryDTO
	{
		public Guid BookId { get; set; }

		public Guid BookInventoryId { get; set; }

		public string Note { get; set; }

		public DateTime OccurredDate { get; set; }
	}
}