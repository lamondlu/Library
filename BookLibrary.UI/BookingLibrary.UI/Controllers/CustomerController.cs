using BookingLibrary.UI.SessionStorages;
using BookingLibrary.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingLibrary.UI.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(ISessionStorage sessionStorage) : base(sessionStorage)
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