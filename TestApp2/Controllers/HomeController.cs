﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace TestApp2.Controllers
{
    public class HomeController : _Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}