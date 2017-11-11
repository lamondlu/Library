using BookingLibrary.UI.SessionStorages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}