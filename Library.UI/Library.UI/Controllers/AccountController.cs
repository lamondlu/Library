using BookingLibrary.UI.Consts;
using Library.UI.DTOs;
using Library.UI.Models;
using Library.UI.SessionStorages;
using Library.UI.Utilities;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Library.UI.Controllers
{
    public class AccountController : Controller
    {
        private string _identityApiBaseUrl => ConfigurationManager.AppSettings["identityApiUrl"];

        protected ISessionStorage _sessionStorage = null;

        public AccountController()
        {
            _sessionStorage = new RedisSessionStorage(ConfigurationManager.AppSettings["redisServerIp"], Convert.ToInt32(ConfigurationManager.AppSettings["redisServerPort"]));
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
            var url = $"{_identityApiBaseUrl}/api/identities";

            var validationResult = ApiRequest.Post<IdentityDTO>(ServiceConsts.IdentityServiceApiName, url, model);

            if (validationResult != null && validationResult.UserId != Guid.Empty)
            {
                var cookie = new HttpCookie("UserId", validationResult.UserId.ToString());
                cookie.Expires = DateTime.Now.AddMinutes(10);

                var user = ApiRequest.Get<IdentityDetailsDTO>(ServiceConsts.IdentityServiceApiName, $"{_identityApiBaseUrl}/api/accounts/{validationResult.UserId.ToString()}");
                _sessionStorage.Set<IdentityDetailsDTO>(validationResult.UserId.ToString(), user);

                Response.Cookies.Add(cookie);

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