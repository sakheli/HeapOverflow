﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeapOverflow.Controllers
{
    public class HomeController : Controller
    {
        [Auth]
        public ActionResult Index()
        {
            return View();
        }

        [Auth]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Auth]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}