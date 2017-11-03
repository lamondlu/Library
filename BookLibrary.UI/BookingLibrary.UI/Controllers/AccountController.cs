using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BookingLibrary.UI.Models;
using BookingLibrary.UI.Utilities;
using BookingLibrary.UI.DTOs;
using System.Configuration;
using System.Net;
using System.Web.Security;
using System.Collections.Specialized;

namespace BookingLibrary.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private string _identityApiBaseUrl => ConfigurationManager.AppSettings["identityApiUrl"];

        public AccountController()
        {

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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            var url = $"{_identityApiBaseUrl}/api/identities";

            var datas = new NameValueCollection();
            datas.Add("UserName", model.UserName);
            datas.Add("Password", model.Password);

            var validationResult = ApiRequestWithFormUrlEncodedContent.Post<IdentityDTO>(url, datas);

            if (validationResult.UserId != Guid.Empty)
            {
                FormsAuthentication.SetAuthCookie(validationResult.UserId.ToString(), false);
                return RedirectToAction("List", "Book");
            }

            return View();
        }
    }
}