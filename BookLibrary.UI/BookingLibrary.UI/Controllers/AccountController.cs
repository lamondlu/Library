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
using BookingLibrary.UI.SessionStorages;

namespace BookingLibrary.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private string _identityApiBaseUrl => ConfigurationManager.AppSettings["identityApiUrl"];

        protected ISessionStorage _sessionStorage = null;

        public AccountController()
        {
            _sessionStorage = new RedisSessionStorage("192.168.1.105", 6379);
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
                _sessionStorage.Set<Guid>("currentUserKey", validationResult.UserId);
                FormsAuthentication.SetAuthCookie(validationResult.UserId.ToString(), false);
                return RedirectToAction("List", "Book");
            }

            return View();
        }
    }
}