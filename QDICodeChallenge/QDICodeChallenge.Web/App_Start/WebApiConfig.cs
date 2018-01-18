using System.Web.Http;

namespace QDICodeChallenge.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/contact/{id}",
                defaults: new { 
                    controller = "ContactAPI",
                    id = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "ApiName",
                routeTemplate: "api/contact/{firstname}/{lastname}",
                defaults: new {
                    controller = "ContactAPI"
                },
                constraints: new { firstname = @"^[a-zA-Z \.'\-]+$", lastname = @"^[a-zA-Z \.'\-]+$" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
