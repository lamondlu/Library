using BookingLibrary.UI.Consts;
using BookingLibrary.UI.DTOs;
using Library.UI.DTOs;
using Library.UI.Utilities;
using Library.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;

namespace Library.UI.Controllers
{
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
            var commandKey = ApiRequestWithStringContent.Post<Guid>(ServiceConsts.InventoryServiceApiName, $"{_inventoryApiBaseUrl}/api/Books/{dto.BookId}/Inventories", new ImportBookInventoryDTO
            {
                BookInventoryIds = newBookInventories
            });

            return Content(commandKey.ToString());
        }

        [HttpGet]
        public ActionResult Histories(Guid id)
        {
            var histories = ApiRequestWithStringContent.Get<List<BookInventoryHistoryViewModel>>(ServiceConsts.InventoryServiceApiName, $"{_inventoryApiBaseUrl}/api/inventories/{id}/histories");
            return View(histories);
        }

        [HttpPut]
        public ActionResult InStore(InStoreBookInventoryDTO dto)
        {
            var commandKey = ApiRequestWithStringContent.Put<Guid>(ServiceConsts.InventoryServiceApiName, $"{_inventoryApiBaseUrl}/api/inventories/{dto.BookInventoryId}/status", new
            {
                Status = 1,
                Notes = dto.Note,
                OccurredDate = dto.OccurredDate
            });

            return Content(commandKey.ToString());
        }

        [HttpPut]
        public ActionResult OutStore(OutStoreBookInventoryDTO dto)
        {
            var commandKey = ApiRequestWithStringContent.Put<Guid>(ServiceConsts.InventoryServiceApiName, $"{_inventoryApiBaseUrl}/api/inventories/{dto.BookInventoryId}/status", new
            {
                Status = 2,
                Notes = dto.Note,
                OccurredDate = dto.OccurredDate
            });

            return Content(commandKey.ToString());
        }
    }
}