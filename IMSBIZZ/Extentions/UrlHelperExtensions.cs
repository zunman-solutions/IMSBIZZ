using IMSBIZZ.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IMSBIZZ.Extentions
{
    public static class UrlHelperExtensions
    {
       
        public static string /* go to hell */ GetJsonRouteData(this UrlHelper urlHelper)
        {
            var httpContext = new HttpContextWrapper(System.Web.HttpContext.Current);

            var routeData = urlHelper.RouteCollection.GetRouteData(httpContext);
            return string.Format("{{  controller: '{0}' }}", routeData.Values["controller"].ToString());
        }

    }
}