
namespace Library.Service.Identity.Domain
{
	public class PlainTextPasswordHasher : IPasswordHasher
	{
		public string HashPassword(string password)
		{
			return password;
		}
	}
}