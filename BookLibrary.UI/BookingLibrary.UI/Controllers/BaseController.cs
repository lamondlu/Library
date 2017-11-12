using BookingLibrary.UI.SessionStorages;
using BookingLibrary.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookingLibrary.UI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string _repositoryApiBaseUrl => ConfigurationManager.AppSettings["repositoryApiUrl"];

        protected string _identityApiBaseUrl => ConfigurationManager.AppSettings["identityApiUrl"];

        protected string _leaseApiBaseUrl => ConfigurationManager.AppSettings["leaseApiUrl"];

        protected ISessionStorage _sessionStorage = null;

        public BaseController()
        {
            _sessionStorage = new RedisSessionStorage("192.168.1.105", 6379);
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            var user = ApiRequestWithStringContent.Get<IdentityDetailsDTO>($"{_identityApiBaseUrl}/api/accounts/{User.Identity.Name.ToString()}");
            ViewBag.CurrentUser = user;
            return base.BeginExecuteCore(callback, state);
        }
    }
}