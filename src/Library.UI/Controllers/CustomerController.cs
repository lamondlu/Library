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
			var data = ApiRequest.Get<List<CustomerViewModel>>($"{_apiGatewayUrl}/api/customers");
			return Json(data, JsonRequestBehavior.AllowGet);
		}
	}
}