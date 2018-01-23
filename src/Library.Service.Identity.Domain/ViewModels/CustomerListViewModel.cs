using System;

namespace Library.Service.Identity.Domain.ViewModels
{
	public class CustomerListViewModel
	{
		public Guid CustomerId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }
	}
}