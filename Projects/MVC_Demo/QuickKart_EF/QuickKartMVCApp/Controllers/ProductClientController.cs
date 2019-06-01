using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using QuickKartMVCApp.Repository;

namespace QuickKartMVCApp.Controllers
{
    public class ProductClientController : Controller
    {
        // GET: ProductClient
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Product/GetProducts");
                response.EnsureSuccessStatusCode();
                var products = response.Content.ReadAsAsync<IEnumerable<Models.Product>>().Result;
                ViewBag.Title = "Index";
                return View(products);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: ProductClient/Details/5
        public ActionResult Details(Models.Product product)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Product/GetProduct?ProductId=" + product.ProductId);
                response.EnsureSuccessStatusCode();
                var productObj = response.Content.ReadAsAsync<Models.Product>().Result;
                return View(productObj);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: ProductClient/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // POST: ProductClient/Create
        [HttpPost]
        public ActionResult Create(Models.Product prodObj)
        {
            try
            {
                // TODO: Add insert logic here
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostRequest("api/product/InsertProduct", prodObj);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductClient/Edit/5
        public ActionResult Edit(Models.Product product)
        {
            return View(product);
        }

        // POST: ProductClient/Edit/5
        [HttpPost]
        public ActionResult UpdateProduct(Models.Product product)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage resp = serviceObj.PutRequest("api/Product/UpdateProduct", product);
                resp.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ProductClient/Delete/5
        public ActionResult Delete(Models.Product product)
        {
            try
            {
                return View(product);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: ProductClient/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        [HttpPost]
        public ActionResult DeleteProduct(Models.Product product)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage resp = serviceObj.DeleteRequest("api/Product/DeleteProduct?ProductId=" + product.ProductId);
                resp.EnsureSuccessStatusCode();
                return View("Success");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
