using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Commands
{
	[CommandLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
	[CommandLog(Code = Code_OUTSTORE_COMPLETED, Message = "Command finished.", Type = LogType.Info)]
	public class OutStoreBookInventoryCommand : CommonCommand
	{
		private static string OutStoreBookInventoryCommandKey = "Command_OutStoreInventoryBook";
		public const string Code_OUTSTORE_COMPLETED = "OUTSTORE_COMPLETED";

		public OutStoreBookInventoryCommand() : base(OutStoreBookInventoryCommandKey)
		{
		}

		public Guid BookInventoryId { get; set; }

		public DateTime OutStoreDate { get; set; }

		public string Notes { get; set; }
	}
}