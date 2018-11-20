using System.Web.Http;
using System.Web.Mvc;

namespace MASGlobal.HandsOn.Website.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Get Employees",
                routeTemplate: "api/v1/employees",
                defaults: new { controller = "Service", action = "GetEmployees" }
            );

            config.Routes.MapHttpRoute(
                name: "Get Employee",
                routeTemplate: "api/v1/employees/{id}",
                defaults: new { controller = "Service", action = "GetEmployee", id = UrlParameter.Optional }
            );
        }
    }
}