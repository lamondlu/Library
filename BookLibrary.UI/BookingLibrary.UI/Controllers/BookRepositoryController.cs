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
    [Authorize]
    public class BookRepositoryController : Controller
    {
        private string _repositoryApiBaseUrl => ConfigurationManager.AppSettings["repositoryApiUrl"];

        [HttpGet]
        public ActionResult List()
        {
            var data = ApiRequest.Get<List<BookViewModel>>($"{_repositoryApiBaseUrl}/api/BookRepository");
            return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var data = ApiRequest.Get<EditBookRepositoryDTO>($"{_repositoryApiBaseUrl}/api/BookRepository/{id}");

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, EditBookRepositoryDTO dto)
        {
            var data = new NameValueCollection();

            data.Add("BookId", dto.BookId.ToString());
            data.Add("BookName", dto.BookName);
            data.Add("ISBN", dto.ISBN);
            data.Add("IssueDate", dto.DateIssued.ToString("yyyy-MM-dd"));
            data.Add("Description", dto.Description);

            var commandId = ApiRequest.Put<Guid>($"{_repositoryApiBaseUrl}/api/BookRepository/{dto.BookId}", data);

            if (commandId != Guid.Empty)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View(dto);
            }
        }

        [HttpPost]
        public ActionResult Add(AddBookRepositoryDTO dto)
        {
            var data = new NameValueCollection();

            data.Add("BookName", dto.BookName);
            data.Add("ISBN", dto.ISBN);
            data.Add("IssueDate", dto.IssueDate.ToString("yyyy-MM-dd"));
            data.Add("Description", dto.Description);

            var commandId = ApiRequest.Post<Guid>($"{_repositoryApiBaseUrl}/api/BookRepository", data);

            if (commandId != Guid.Empty)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View(dto);
            }
        }
    }
}