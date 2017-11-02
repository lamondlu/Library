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

        public BookRepositoryController()
        {

        }

        [HttpPost]
        public ActionResult _AjaxBulkImported(Guid bookId)
        {
            List<Guid> newBookRepositories = new List<Guid>();

            //hard code 10 repsitory id
            for (var i = 0; i < 10; i++)
            {
                newBookRepositories.Add(Guid.NewGuid());
            }

            var data = new NameValueCollection();
            data.Add("BookRepositoryIds", string.Join(",", newBookRepositories.Select(p => p.ToString())));
            var commandKey = ApiRequest.Post<Guid>($"{_repositoryApiBaseUrl}/api/Books/{bookId}/Repositories", data);

            return View(commandKey);
        }
    }
}