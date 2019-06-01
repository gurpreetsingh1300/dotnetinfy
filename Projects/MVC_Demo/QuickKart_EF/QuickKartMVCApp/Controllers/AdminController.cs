using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickKartMVCApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminHome()
        {

            //return View();
            return RedirectToAction("Index", "ProductClient");
        }
    }
}