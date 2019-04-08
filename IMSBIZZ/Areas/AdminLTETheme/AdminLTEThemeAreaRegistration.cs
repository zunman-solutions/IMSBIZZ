using System.Web.Mvc;

namespace IMSBIZZ.Areas.AdminLTETheme
{
    public class AdminLTEThemeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminLTETheme";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminLTETheme_default",
                "AdminLTETheme/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}