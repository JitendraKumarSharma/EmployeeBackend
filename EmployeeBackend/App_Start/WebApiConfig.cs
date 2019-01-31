//using EmployeeBackend.ExceptionHandle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace EmployeeBackend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ////Use Filter here at global level or top of the action method like in UserController
            //config.Filters.Add(new ValidationFilters.ValidateRegistration());

            // Web API configuration and services
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new System.Net.Http.Formatting.QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
