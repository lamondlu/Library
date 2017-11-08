using BookingLibrary.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingLibrary.UI.Controllers
{
    public class CustomerController : Controller
    {
        private string _identityApiBaseUrl => ConfigurationManager.AppSettings["identityApiUrl"];

        public CustomerController()
        {

        }

        [HttpGet]
        // GET: Customer
        public ActionResult _AjaxGetAllCustomers()
        {
            var data = ApiRequestWithFormUrlEncodedContent.Get<List<CustomerViewModel>>($"{_identityApiBaseUrl}/api/customers");
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}