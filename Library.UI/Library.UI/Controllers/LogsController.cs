using Library.UI.Controllers;
using Library.UI.Models;
using Library.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingLibrary.UI.Controllers
{
    public class LogsController : BaseController
    {
        public ActionResult List()
        {
            var data = ApiRequestWithStringContent.Get<List<LoginViewModel>>($"{_logApiBaseUrl}/api/CommandLogs");
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}