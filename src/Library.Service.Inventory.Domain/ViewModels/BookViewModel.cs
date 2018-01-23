using System;

namespace Library.Service.Inventory.Domain.ViewModels
{
	public class BookViewModel
	{
		public Guid BookId { get; set; }

		public string ISBN { get; set; }

		public string BookName { get; set; }

		public string Description { get; set; }

		public DateTime DateIssued { get; set; }
	}
}