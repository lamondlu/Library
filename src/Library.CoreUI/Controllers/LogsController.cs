using Library.CoreUI.Controllers;
using Library.CoreUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Library.CoreUI.Models;

namespace BookingLibrary.CoreUI.Controllers
{
	public class LogsController : BaseController
	{
        public LogsController(IOptions<ConfigurationModel> configAccessor) : base(configAccessor)
        {

        }

		public ActionResult List()
		{
			var data = ApiRequest.Get<List<BookingLibrary.CoreUI.Models.LogItemViewModel>>($"{_apiGatewayUrl}/api/commandLogs");
			return View(data);
		}

		public ActionResult _AjaxListItem(Guid commandUniqueId)
		{
			var data = ApiRequest.Get<List<BookingLibrary.CoreUI.Models.LogItemViewModel>>($"{_apiGatewayUrl}/api/commandLogs/{commandUniqueId}/eventLogs");

			if (data.Count > 0)
			{
				data = data.OrderByDescending(p => p.CreatedOn).ToList();
			}

			return PartialView("_EventLogs", data);
		}
	}
}