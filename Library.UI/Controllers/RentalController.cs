using Library.UI.DTOs;
using Library.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.UI.Controllers
{
	public class RentalController : BaseController
	{
		public RentalController()
		{
		}

		public ActionResult UnreturnedBooks()
		{
			var data = ApiRequest.Get<List<UnreturnedBookViewModel>>($"{_apiGatewayUrl}/api/unreturned_books");
			return View(data);
		}

		[HttpPost]
		public ActionResult _AjaxRentBook(RentBookDTO dto)
		{
			var bookInfo = ApiRequest.Get<EditBookDTO>($"{_apiGatewayUrl}/api/books/{dto.BookId}");

			var bookInventoryId = bookInfo.BookInventories.Where(p => p.Status == 1).FirstOrDefault()?.BookInventoryId;

			if (bookInventoryId.HasValue)
			{
				var commandId = ApiRequest.Post<Guid>($"{_apiGatewayUrl}/api/customers/{dto.CustomerId}/books", new
				{
					BookId = bookInventoryId,
					BookName = bookInfo.BookName,
					ISBN = bookInfo.ISBN,
					CustomerId = dto.CustomerId,
					Name = new
					{
						FirstName = "Lily",
						MiddleName = string.Empty,
						LastName = "Jiang"
					}
				});

				return Json(new { result = true, commandId = commandId });
			}
			else
			{
				return Json(new { result = false, errorMessage = "Book has been rented, please try again." });
			}
		}

		[HttpPost]
		public ActionResult _AjaxReturnBook(Guid customerId, Guid bookId)
		{
			var commandId = ApiRequest.Delete<Guid>($"{_apiGatewayUrl}/api/customers/{customerId}/books/{bookId}");

			return Json(new { result = true, commandId = commandId });
		}
	}
}