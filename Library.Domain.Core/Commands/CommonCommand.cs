namespace Library.Domain.Core.Commands
{
	public class CommonCommand : CommandBase
	{
		public const string Code_SERVER_ERROR = "SERVER_ERROR";

		public CommonCommand(string key) : base(key)
		{
		}
	}
}