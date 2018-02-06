using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Identity.DTOs
{
	public class CustomerDTO
	{
		public string UserName { get; set; }

		public string Password { get; set; }

		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }
	}
}
