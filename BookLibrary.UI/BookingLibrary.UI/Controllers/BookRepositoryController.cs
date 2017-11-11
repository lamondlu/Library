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
    [Authorize]
    public class BookRepositoryController : BaseController
    {
        public BookRepositoryController() 
        {

        }

        [HttpPost]
        public ActionResult _AjaxBulkImported(BulkImportDTO dto)
        {
            List<Guid> newBookRepositories = new List<Guid>();

            //hard code 10 repsitory id
            for (var i = 0; i < dto.Number; i++)
            {
                newBookRepositories.Add(Guid.NewGuid());
            }

            var data = new NameValueCollection();
            data.Add("BookRepositoryIds", string.Join(",", newBookRepositories.Select(p => p.ToString())));
            var commandKey = ApiRequestWithStringContent.Post<Guid>($"{_repositoryApiBaseUrl}/api/Books/{dto.BookId}/Repositories", new ImportBookRepositoryDTO
            {
                BookRepositoryIds = newBookRepositories
            });

            return Content(commandKey.ToString());
        }

        
    }
}