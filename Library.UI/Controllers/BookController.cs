using Library.UI.DTOs;
using Library.UI.Utilities;
using Library.UI.ViewModels;
using System;
using System.Collections.Generic;
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
			var data = ApiRequest.Get<List<BookViewModel>>($"{_inventoryApiBaseUrl}/api/Books");
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
			var data = ApiRequest.Get<EditBookDTO>($"{_inventoryApiBaseUrl}/api/Books/{id}");

			return View(data);
		}

		[HttpPost]
		public ActionResult Edit(Guid id, EditBookDTO dto)
		{
			var commandId = ApiRequest.Put<Guid>($"{_inventoryApiBaseUrl}/api/Books/{dto.BookId}", dto);

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
			var commandUnqiueId = ApiRequest.Post<Guid>($"{_inventoryApiBaseUrl}/api/Books", dto);

			return Json(new { commandUnqiueId = commandUnqiueId });
		}

		[HttpGet]
		public ActionResult _AjaxGetAvailableBooks()
		{
			var data = ApiRequest.Get<List<AvailableBookModel>>($"{_inventoryApiBaseUrl}/api/available_books");
			return Json(data, JsonRequestBehavior.AllowGet);
		}
	}
}