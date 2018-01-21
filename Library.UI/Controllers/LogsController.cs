using Library.UI.Controllers;
using Library.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookingLibrary.UI.Controllers
{
	public class LogsController : BaseController
	{
		public ActionResult List()
		{
			var data = ApiRequest.Get<List<BookingLibrary.UI.Models.LogItemViewModel>>($"{_apiGatewayUrl}/api/commandLogs");
			return View(data);
		}

		public ActionResult _AjaxListItem(Guid commandUniqueId)
		{
			var data = ApiRequest.Get<List<BookingLibrary.UI.Models.LogItemViewModel>>($"{_apiGatewayUrl}/api/commandLogs/{commandUniqueId}/eventLogs");

			if (data.Count > 0)
			{
				data = data.OrderByDescending(p => p.CreatedOn).ToList();
			}

			return PartialView("_EventLogs", data);
		}
	}
}