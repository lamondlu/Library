using Library.UI.Controllers;
using Library.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using BookingLibrary.UI.Consts;

namespace BookingLibrary.UI.Controllers
{
    public class LogsController : BaseController
    {
        public ActionResult List()
        {
            var data = ApiRequestWithStringContent.Get<List<BookingLibrary.UI.Models.LogItemViewModel>>(ServiceConsts.LogServiceApiName, $"{_logApiBaseUrl}/api/CommandLogs");
            return View(data);
        }

        public ActionResult _AjaxListItem(Guid commandUniqueId)
        {
            var data = ApiRequestWithStringContent.Get<List<BookingLibrary.UI.Models.LogItemViewModel>>(ServiceConsts.LogServiceApiName, $"{_logApiBaseUrl}/api/CommandLogs/{commandUniqueId}/EventLogs");

            if (data.Count > 0)
            {
                data = data.OrderByDescending(p => p.CreatedOn).ToList();
            }

            return PartialView("_EventLogs", data);
        }
    }
}