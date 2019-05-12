using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickKartDataAccessLayer;

namespace QuickKartMVCApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CheckRole(FormCollection frm)
        {
            QuickKartRepository repObj = new QuickKartRepository();
            string userId = frm["name"];
            string password = frm["pwd"];
            string role = repObj.ValidateLoginUsingLinq(userId, password);
            //if (repObj.ValidateCredentials(userId, password))
            //{
            //    byte? roleId = repObj.GetRoleIdByUserId(userId);
            //}
            if (role.ToLower().Equals("admin"))
            {
                return RedirectToAction("AdminHome", "Admin");
            }
            else if (role.ToLower().Equals("customer"))
            {
                return RedirectToAction("CustomerHome", "Customer");
            }
            return View("Login");
        }
        public JsonResult GetCoupons()
        {
            Random random = new Random();
            Dictionary<string, string> data = new Dictionary<string, string>();
            string[] value = new String[5];
            string[] key = { "Arts", "Electronics", "Fashion", "Home", "Toys" };
            for (int i = 0; i < 5; i++)
            {
                string number = "RUSH" + random.Next(1, 10).ToString() + random.Next(1, 10).ToString() + random.Next(1, 10).ToString();
                value[i] = number;
            }
            for (int i = 0; i < 5; i++)
            {
                data.Add(key[i], value[i]);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}