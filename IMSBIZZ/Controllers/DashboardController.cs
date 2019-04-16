using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSBIZZ.Controllers
{
    /// <summary>
    /// DashBoard Controller
    /// </summary>
    public class DashboardController : Controller
    {
        /// <summary>
        /// Dashboard Action
        /// </summary>
        /// <returns></returns>
        public ActionResult Dashboard()
        {
            return View();
        }

    }
}