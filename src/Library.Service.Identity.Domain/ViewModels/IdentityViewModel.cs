using System;

namespace Library.Service.Identity.Domain.ViewModels
{
	public class IdentityViewModel
	{
		public Guid UserId { get; set; }

		public string Role { get; set; }
	}
}