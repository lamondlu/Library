using BookingLibrary.UI.Consts;
using Library.UI.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.UI.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController()
        {
        }

        [HttpGet]
        // GET: Customer
        public ActionResult _AjaxGetAllCustomers()
        {
            var data = ApiRequestWithFormUrlEncodedContent.Get<List<CustomerViewModel>>(ServiceConsts.IdentityServiceApiName, $"{_identityApiBaseUrl}/api/customers");
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}