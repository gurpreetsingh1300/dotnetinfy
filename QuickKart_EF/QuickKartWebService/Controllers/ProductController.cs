using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using QuickKartDataAccessLayer;
using QuickKartWebService.Repository;

namespace QuickKartWebService.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        [HttpGet]
        public JsonResult<List<Models.Product>> GetProducts()
        {
            var mapObj = new QuickKartMapper<Product, Models.Product>();
            var dal = new QuickKartRepository();
            var productList = dal.GetProducts();
            var products = new List<Models.Product>();
            if (productList.Any())
            {
                foreach (var product in productList)
                {
                    products.Add(mapObj.Translate(product));
                }
            }
            return Json<List<Models.Product>>(products);
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
