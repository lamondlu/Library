namespace Library.Service.Identity.Domain
{
	public interface IPasswordHasher
	{
		string HashPassword(string password);
	}
}