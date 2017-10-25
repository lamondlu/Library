using BookingLibrary.UI.Utilities;
using System;
using System.Collections.Generic;
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

        // GET: BookRepositoy
        public ActionResult List()
        {
            var data = ApiRequest.Get<List<BookViewModel>>($"{_repositoryApiBaseUrl}/api/BookRepository");
            return View(data);
        }
    }
}