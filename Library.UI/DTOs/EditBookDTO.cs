using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.UI.DTOs
{
	public class EditBookDTO
	{
		public Guid BookId { get; set; }

		[Required]
		public string BookName { get; set; }

		[Required]
		public string ISBN { get; set; }

		[Required]
		public DateTime DateIssued { get; set; }

		public string Description { get; set; }

		public List<BookInventoryDTO> BookInventories { get; set; }
	}

	public class BookInventoryDTO
	{
		public Guid BookInventoryId { get; set; }

		public string LastNote { get; set; }

		public int Status { get; set; }
	}
}