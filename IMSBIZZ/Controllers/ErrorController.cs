﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSBIZZ.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PageNotFound()
        {
            return View();
        }
        public ActionResult ServerSideError()
        {
            return View();
        }
        public ActionResult CustomErrors()
        {
            return View();
        }
        public ActionResult UnauthorizedAccess()
        {
            return View();
        }
    }
}