using System;

namespace Library.CoreUI
{
	public class UnreturnedBookViewModel
	{
		public Guid BookId { get; set; }

		public Guid CustomerId { get; set; }

		public string BookName { get; set; }

		public string ISBN { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public DateTime RentDate { get; set; }
	}
}