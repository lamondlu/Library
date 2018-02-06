using BookingLibrary.UI.DTOs;
using Library.UI.Utilities;
using System;
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

		[HttpGet]
		public ActionResult List()
		{
			var data = ApiRequest.Get<List<CustomerViewModel>>($"{_apiGatewayUrl}/api/customers");
			return View(data);
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(AddCustomerDTO dto)
		{
			var commandUnqiueId = ApiRequest.Post<Guid>($"{_apiGatewayUrl}/api/customers", dto);

			return Json(new { commandUnqiueId = commandUnqiueId });
		}
	}
}