using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.Helper;
using IMSBIZZ.Models;
using System;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace IMSBIZZ.Controllers
{
    
    public class HomeController : Controller
    {
        
        

        public HomeController()
        {
           
        }

        public ActionResult Index()
        {
            return View();
        }

        //added by ather
        public ActionResult Website()
        {
            return View();
        }
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}