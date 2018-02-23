using Library.CoreUI.DTOs;
using Library.CoreUI.Utilities;
using Library.CoreUI.ViewModels;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Library.CoreUI.Models;

namespace Library.CoreUI.Controllers
{
    public class BookController : BaseController
    {

        public BookController(IOptions<ConfigurationModel> configAccessor) : base(configAccessor)
        {

        }

        [HttpGet]
        public ActionResult List()
        {
            var data = ApiRequest.Get<List<BookViewModel>>($"{_apiGatewayUrl}/api/books");
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
            var data = ApiRequest.Get<EditBookDTO>($"{_apiGatewayUrl}/api/books/{id}");

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, EditBookDTO dto)
        {
            var commandId = ApiRequest.Put<Guid>($"{_apiGatewayUrl}/api/books/{dto.BookId}", dto);

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
            var commandUnqiueId = ApiRequest.Post<Guid>($"{_apiGatewayUrl}/api/books", dto);

            return Json(new { commandUnqiueId = commandUnqiueId });
        }

        [HttpGet]
        public ActionResult _AjaxGetAvailableBooks()
        {
            var data = ApiRequest.Get<List<AvailableBookModel>>($"{_apiGatewayUrl}/api/available_books");
            return Json(data);
        }
    }
}