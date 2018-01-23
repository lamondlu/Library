using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Commands
{
	[CommandLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
	[CommandLog(Code = Code_INSTORE_COMPLETED, Message = "Command finished.", Type = LogType.Info)]
	public class InStoreBookInventoryCommand : CommonCommand
	{
		private static string InStoreBookInventoryCommandKey = "Command_InStoreBookInventory";
		public const string Code_INSTORE_COMPLETED = "INSTORE_COMPLETED";

		public InStoreBookInventoryCommand() : base(InStoreBookInventoryCommandKey)
		{
		}

		public Guid BookId { get; set; }

		public Guid BookInventoryId { get; set; }

		public DateTime InStoreDate { get; set; }

		public string Notes { get; set; }
	}
}