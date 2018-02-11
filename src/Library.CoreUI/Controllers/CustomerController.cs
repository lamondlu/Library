using BookingLibrary.CoreUI.DTOs;
using Library.CoreUI.DTOs;
using Library.CoreUI.Utilities;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Library.CoreUI.Controllers
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
			return Json(data);
		}
	}
}