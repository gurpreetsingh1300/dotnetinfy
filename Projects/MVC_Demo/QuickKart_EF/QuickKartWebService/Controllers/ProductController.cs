﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using QuickKartDataAccessLayer;
using QuickKartWebService.Repository;
using AutoMapper;

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

        [HttpGet]
        public JsonResult<Models.Product> GetProduct(string productId)
        {
            try
            {
                QuickKartMapper<Product, Models.Product> mapper = new QuickKartMapper<Product, Models.Product>();
                var dal = new QuickKartRepository();
                var productObj = dal.GetProductDetails(productId);
                var product = new Models.Product();
                product = mapper.Translate(productObj);
                var product2 = AutoMapper.Mapper.Map<Models.Product>(productObj);
                return Json<Models.Product>(product2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPost]
        public bool InsertProduct(Models.Product product)
        {
            var status = false;
            try
            {
                //var mapper = new QuickKartMapper<Models.Product, Product>();
                var dal = new QuickKartRepository();                
                product.ProductId = dal.GetNextProductIdUsingUFN();
                var entityProduct = AutoMapper.Mapper.Map<Product>(product);
                status = dal.AddProduct(entityProduct);
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        [HttpPut]
        public bool UpdateProduct(Models.Product product)
        {
            var status = false;
            try
            {                
                var dal = new QuickKartRepository();
                status = dal.UpdateProduct(AutoMapper.Mapper.Map<Product>(product));
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        [HttpDelete]
        public bool DeleteProduct(string productId)
        {
            var status = false;
            try
            {
                var dal = new QuickKartRepository();
                status = dal.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
    }
}
