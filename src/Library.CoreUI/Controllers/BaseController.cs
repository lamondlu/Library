using Library.CoreUI.Models;
using Library.CoreUI.SessionStorages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace Library.CoreUI.Controllers
{
    public class BaseController : Controller
    {
        protected string _apiGatewayUrl = string.Empty;
        private ConfigurationModel _configuration = null;
        protected ISessionStorage _sessionStorage = null;

        public BaseController(IOptions<ConfigurationModel> configAccessor)
        {
            _configuration = configAccessor.Value;

            _sessionStorage = new RedisSessionStorage(_configuration.RedisServerIp, Convert.ToInt32(_configuration.RedisServerPort));
            _apiGatewayUrl = _configuration.ApiGatewayUrl;

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.SignalRUrl = _configuration.SignalRUrl;
            var cookie = Request.Cookies["UserId"];

            if (cookie == null)
            {
                Response.Redirect("~/Account/Login");
            }
            else
            {
                var userId = cookie;
                var user = _sessionStorage.Get<IdentityDetailsDTO>(userId);

                ViewBag.CurrentUser = user;
            }

            base.OnActionExecuting(context);
        }
    }
}