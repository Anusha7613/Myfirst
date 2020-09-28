using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Myfirst
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    name:"CustomerByDOB",
            //    url:"{controller}/{action}/{DOB}",
            //    defaults:new {controller="Customer",action="FindAge",DOB=UrlParameter.Optional}
            //    );
            //routes.MapRoute(
            //    name: "MovieByHeroNameAndrelease",
            //    url:"{ controller}/{action}/{HeroName}/{release}",
            //    defaults: new {controller="Movie",action="SearchMovie",release=UrlParameter.Optional}
            //    ); 
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
                //new[] { "Mvc4_Route" })
            );
        }
    }
}
