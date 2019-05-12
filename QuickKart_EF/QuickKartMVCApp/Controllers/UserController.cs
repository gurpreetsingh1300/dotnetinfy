using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickKartDataAccessLayer;

namespace QuickKartMVCApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult RegisterUser()
        {
            return View();
        }
        public ActionResult SaveRegisterUser(Models.User userObj)
        {
            if (ModelState.IsValid)
            {
                QuickKartRepository dal = new QuickKartRepository();
                var returnValue = dal.RegisterUser(userObj.EmailId, userObj.UserPassword, userObj.Gender, userObj.DateOfBirth, userObj.Address);
                if (returnValue)
                    return RedirectToAction("Login", "Home");
                else
                    return View("Error");
            }
            return View("RegisterUser");
        }
    }
}