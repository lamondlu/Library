using Library.CoreUI.SessionStorages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Library.CoreUI.Controllers
{
    public class BaseController : Controller
    {
        private IConfigurationRoot _configuration = null;
        protected string _apiGatewayUrl = string.Empty;

        protected ISessionStorage _sessionStorage = null;

        public BaseController()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            _sessionStorage = new RedisSessionStorage(_configuration["redisServerIp"], Convert.ToInt32(_configuration["redisServerPort"]));
            _apiGatewayUrl = _configuration["apiGatewayUrl"];

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
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