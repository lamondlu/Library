using Library.CoreUI.DTOs;
using Library.CoreUI.Models;
using Library.CoreUI.SessionStorages;
using Library.CoreUI.Utilities;
using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Library.CoreUI.Controllers
{
	public class AccountController : Controller
	{
        private IConfigurationRoot _configuration = null;
        protected string _apiGatewayUrl = string.Empty;
        

		protected ISessionStorage _sessionStorage = null;

		public AccountController()
		{
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            _sessionStorage = new RedisSessionStorage(_configuration["redisServerIp"], Convert.ToInt32(_configuration["redisServerPort"]));
            _apiGatewayUrl = _configuration["apiGatewayUrl"];
        }

		//
		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		//
		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
		{
			var url = $"{_apiGatewayUrl}/api/identities";

			var validationResult = ApiRequest.Post<IdentityDTO>(url, model);

			if (validationResult != null && validationResult.UserId != Guid.Empty)
			{
				var user = ApiRequest.Get<IdentityDetailsDTO>($"{_apiGatewayUrl}/api/accounts/{validationResult.UserId.ToString()}");
				_sessionStorage.Set<IdentityDetailsDTO>(validationResult.UserId.ToString(), user);


                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(10);

                Response.Cookies.Append("UserId", validationResult.UserId.ToString(), option);

                return RedirectToAction("List", "Book");
			}
			else
			{
				ModelState.AddModelError("LoginFailure", "User is not existed or password is wrong.");
				return View();
			}
		}
	}
}