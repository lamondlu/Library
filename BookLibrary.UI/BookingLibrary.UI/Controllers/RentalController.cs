using BookingLibrary.UI.DTOs;
using BookingLibrary.UI.SessionStorages;
using BookingLibrary.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingLibrary.UI.Controllers
{
    public class RentalController : BaseController
    {
        public RentalController() 
        {

        }

        public ActionResult UnreturnedBooks()
        {
            var data = ApiRequestWithFormUrlEncodedContent.Get<List<UnreturnedBookViewModel>>($"{_rentalApiBaseUrl}/api/unreturned_books");
            return View(data);
        }

        [HttpPost]
        public ActionResult _AjaxRentBook(RentBookDTO dto)
        {
            var bookInfo = ApiRequestWithFormUrlEncodedContent.Get<EditBookDTO>($"{_inventoryApiBaseUrl}/api/Books/{dto.BookId}");

            var bookRepositoryId = bookInfo.BookRepositories.Where(p => p.Status == 1).FirstOrDefault()?.BookRepositoryId;

            if (bookRepositoryId.HasValue)
            {
                var commandId = ApiRequestWithStringContent.Post<Guid>($"{_rentalApiBaseUrl}/api/customers/{dto.CustomerId}/books", new
                {
                    BookId = bookRepositoryId,
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
            var commandId = ApiRequestWithStringContent.Delete<Guid>($"{_rentalApiBaseUrl}/api/customers/{customerId}/books/{bookId}");

            return Json(new { result = true, commandId = commandId });
        }
    }
}