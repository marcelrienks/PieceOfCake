﻿using Newtonsoft.Json;
using System.Web.Http;

namespace Scrummage.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            #region Web API configuration and services

            //Prevent endless loops when serialising models with link back to original model through relations
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            
            //Format JSON indented
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented; 

            #endregion

            #region Web API routes

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            #endregion
        }
    }
}