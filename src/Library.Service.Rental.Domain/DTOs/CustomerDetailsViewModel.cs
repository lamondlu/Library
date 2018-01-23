using System;

namespace Library.Service.Rental.Domain.DTOs
{
	public class CustomerDetailsViewModel
	{
		public Guid CustomerId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }
	}
}