using Library.UI.SessionStorages;
using Library.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Library.UI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string _inventoryApiBaseUrl => ConfigurationManager.AppSettings["inventoryApiUrl"];

        protected string _identityApiBaseUrl => ConfigurationManager.AppSettings["identityApiUrl"];

        protected string _rentalApiBaseUrl => ConfigurationManager.AppSettings["rentalApiUrl"];

        protected string _logApiBaseUrl => ConfigurationManager.AppSettings["logApiUrl"];

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