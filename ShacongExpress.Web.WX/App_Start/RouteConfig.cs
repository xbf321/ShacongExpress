using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShacongExpress.Web.WX
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
             passport/shipper/register
            passport/shipper/register_success
            passport/shipper/auth
            passport/shipper/auth_success

            passport/motorcade/register
            passport/motorcade/register_success
            passport/motorcade/auth
            passport/motorcade/auth_success
             */

            //微信接口
            routes.MapRoute(
                name: "Weixin",
                url: "wx/{action}",
                defaults: new { controller = "WX", action = "Index"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}