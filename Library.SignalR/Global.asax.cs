using System;
using System.Web.Http;

namespace Library.SignalR
{
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			GlobalConfiguration.Configure((config) =>
			{
				// Web API routes
				config.MapHttpAttributeRoutes();

				config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "api/{controller}/{id}",
					defaults: new { id = RouteParameter.Optional }
				);
			});
		}
	}
}