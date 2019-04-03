using IMSBIZZ.Helper;
using System.Web;
using System.Web.Mvc;

namespace IMSBIZZ
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
