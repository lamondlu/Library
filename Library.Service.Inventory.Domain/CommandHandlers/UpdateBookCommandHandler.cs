using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.Commands;
using Library.Service.Inventory.Domain.DataAccessors;
using System;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
	public class UpdateBookCommandHandler : BaseInventoryCommandHandler<UpdateBookCommand>
	{
		public UpdateBookCommandHandler(DomainRepository domainRepository, IInventoryReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger) : base(domainRepository, dataAccesor, tracker, logger)
		{
		}

		public override void ExecuteCore(UpdateBookCommand command)
		{
			try
			{
				var book = _domainRepository.GetById<Book>(command.BookId);

				if (book.BookName != command.BookName)
				{
					book.ChangeBookName(command.BookName);
				}

				if (book.ISBN != command.ISBN)
				{
					book.ChangeISBN(command.ISBN);
				}

				if (book.Description != command.Description)
				{
					book.ChangeDescription(command.Description);
				}

				if (book.DateIssued != command.DateIssued)
				{
					book.ChangeIssuedDate(command.DateIssued);
				}

				_domainRepository.Save(book, book.Version, command.CommandUniqueId);

				command.Result(UpdateBookCommand.Code_BOOK_UPDATED);
			}
			catch (Exception ex)
			{
				command.Result(UpdateBookCommand.Code_SERVER_ERROR, ex.ToString());
			}
		}
	}
}