using Library.Domain.Core;
using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.CommandHandlers;
using Library.Service.Inventory.Domain.DataAccessors;
using System;

namespace Library.Service.Inventory.Domain
{
	public class ImportBookInventoryCommandHandler : BaseInventoryCommandHandler<ImportBookInventoryCommand>
	{
		public ImportBookInventoryCommandHandler(IDomainRepository domainRepository, IInventoryReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger) : base(domainRepository, dataAccesor, tracker, logger)
		{
		}

		public override void ExecuteCore(ImportBookInventoryCommand command)
		{
			try
			{
				if (command.BookInventoryIds == null || command.BookInventoryIds.Count == 0)
				{
					command.Result(ImportBookInventoryCommand.Code_NO_INVENTORY);
					return;
				}

				foreach (var id in command.BookInventoryIds)
				{
					var bookInventory = new BookInventory(id, command.BookId, "Bulk Imported");
					_domainRepository.Save(bookInventory, -1, command.CommandUniqueId);
				}

				command.Result(ImportBookInventoryCommand.Code_IMPORTED_COMPLETED);
			}
			catch (Exception ex)
			{
				command.Result(CommonCommand.Code_SERVER_ERROR, ex.ToString());
			}
		}
	}
}