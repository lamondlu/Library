using System;

namespace Library.CoreUI
{
	public class CustomerViewModel
	{
		public Guid CustomerId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public string CombinedName
		{
			get
			{
				return $"{FirstName} {LastName}";
			}
		}
	}
}