using BookingLibrary.UI.DTOs;
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
    public class LeaseController : Controller
    {
        private string _leaseApiBaseUrl => ConfigurationManager.AppSettings["leaseApiUrl"];
        private string _repositoryApiBaseUrl => ConfigurationManager.AppSettings["repositoryApiUrl"];

        public LeaseController()
        {

        }

        public ActionResult UnreturnedBooks()
        {
            var data = ApiRequestWithFormUrlEncodedContent.Get<List<UnreturnedBookViewModel>>($"{_leaseApiBaseUrl}/api/unreturned_books");
            return View(data);
        }

        [HttpPost]
        public ActionResult _AjaxRentBook(RentBookDTO dto)
        {
            var bookInfo = ApiRequestWithFormUrlEncodedContent.Get<EditBookDTO>($"{_repositoryApiBaseUrl}/api/Books/{dto.BookId}");

            var bookRepositoryId = bookInfo.BookRepositories.Where(p => p.Status == 1).FirstOrDefault()?.BookRepositoryId;

            if (bookRepositoryId.HasValue)
            {
                var commandId = ApiRequestWithStringContent.Post<Guid>($"{_leaseApiBaseUrl}/api/customers/{dto.CustomerId}/books", new
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
            var commandId = ApiRequestWithStringContent.Delete<Guid>($"{_leaseApiBaseUrl}/api/customers/{customerId}/books/{bookId}");

            return Json(new { result = true, commandId = commandId });
        }
    }
}