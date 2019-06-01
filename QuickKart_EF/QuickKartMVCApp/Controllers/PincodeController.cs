using QuickKartMVCApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace QuickKartMVCApp.Controllers
{
    public class PincodeController : Controller
    {
        // GET: Pincode
        public ActionResult Index(Models.Pincode pincode )
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetPincodeResponse("api/pincode/" + pincode.AreaPincode);
            response.EnsureSuccessStatusCode();
            var postoffice = response.Content.ReadAsAsync<Models.Rootobject>().Result;
            var postOffices = postoffice.PostOffice;
            ViewBag.Title = "Index";
            return View(postOffices);            
        }
        public ActionResult AcceptPin()
        {
            return View();
            
        }
        //[HttpPost]
        //public ActionResult AcceptPin(Models.Pincode pincode)
        //{
        //    return RedirectToAction("Index",pincode);
        //}
    }
}