﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VtuberWebsite.Controllers
{
    public class GalleryController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult GalleryShow()
        {
            return View();
        }
    }
}