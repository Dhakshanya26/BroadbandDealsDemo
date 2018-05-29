using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BroadbandDeals.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "Get broadbandDeals",
               routeTemplate: "api/getbroadbanddeals",
               defaults: new { id = RouteParameter.Optional, controller = "BroadbandDeal", action="Get" }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
