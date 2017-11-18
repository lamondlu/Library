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
    [Authorize]
    public class BookInventoryController : BaseController
    {
        public BookInventoryController()
        {

        }

        [HttpPost]
        public ActionResult _AjaxBulkImported(BulkImportDTO dto)
        {
            List<Guid> newBookInventories = new List<Guid>();

            //hard code 10 repsitory id
            for (var i = 0; i < dto.Number; i++)
            {
                newBookInventories.Add(Guid.NewGuid());
            }

            var data = new NameValueCollection();
            data.Add("BookRepositoryIds", string.Join(",", newBookInventories.Select(p => p.ToString())));
            var commandKey = ApiRequestWithStringContent.Post<Guid>($"{_inventoryApiBaseUrl}/api/Books/{dto.BookId}/Inventories", new ImportBookInventoryDTO
            {
                BookInventoryIds = newBookInventories
            });

            return Content(commandKey.ToString());
        }

        [HttpGet]
        public ActionResult Histories(Guid id)
        {
            var histories = ApiRequestWithStringContent.Get<List<BookInventoryHistoryViewModel>>($"{_inventoryApiBaseUrl}/api/inventories/{id}/histories");
            return View(histories);
        }
    }
}