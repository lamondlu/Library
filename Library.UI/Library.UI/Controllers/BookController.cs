using Library.UI.DTOs;
using Library.UI.SessionStorages;
using Library.UI.Utilities;
using Library.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.UI.Controllers
{
    public class BookController : BaseController
    {
        public BookController() 
        {

        }

        [HttpGet]
        public ActionResult List()
        {
            var data = ApiRequestWithFormUrlEncodedContent.Get<List<BookViewModel>>($"{_inventoryApiBaseUrl}/api/Books");
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
            var data = ApiRequestWithFormUrlEncodedContent.Get<EditBookDTO>($"{_inventoryApiBaseUrl}/api/Books/{id}");

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, EditBookDTO dto)
        {
            var data = new NameValueCollection();

            data.Add("BookId", dto.BookId.ToString());
            data.Add("BookName", dto.BookName);
            data.Add("ISBN", dto.ISBN);
            data.Add("IssueDate", dto.DateIssued.ToString("yyyy-MM-dd"));
            data.Add("Description", dto.Description);

            var commandId = ApiRequestWithFormUrlEncodedContent.Put<Guid>($"{_inventoryApiBaseUrl}/api/Books/{dto.BookId}", data);

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
        public ActionResult Add(AddBookDTO dto)
        {
            var data = new NameValueCollection();

            data.Add("BookName", dto.BookName);
            data.Add("ISBN", dto.ISBN);
            data.Add("IssueDate", dto.IssueDate.ToString("yyyy-MM-dd"));
            data.Add("Description", dto.Description);

            var commandUnqiueId = ApiRequestWithFormUrlEncodedContent.Post<Guid>($"{_inventoryApiBaseUrl}/api/Books", data);

            return Json(new { commandUnqiueId = commandUnqiueId });
        }

        [HttpGet]
        public ActionResult _AjaxGetAvailableBooks()
        {
            var data = ApiRequestWithFormUrlEncodedContent.Get<List<AvailableBookModel>>($"{_inventoryApiBaseUrl}/api/available_books");
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}