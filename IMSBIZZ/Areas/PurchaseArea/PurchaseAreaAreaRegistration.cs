using System.Web.Mvc;

namespace IMSBIZZ.Areas.PurchaseArea
{
    /// <summary>
    /// Purchase Area Registration 
    /// </summary>
    public class PurchaseAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Area Name
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "PurchaseArea";
            }
        }

        /// <summary>
        /// Register here your Area Route
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PurchaseArea_default",
                "PurchaseArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}