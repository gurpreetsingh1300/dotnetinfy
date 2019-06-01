using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace QuickKartMVCApp.Repository
{
    public class ServiceRepository
    {
        private HttpClient Client { get; set; }
        public HttpClient PincodeClient { get; set; }
        public ServiceRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl"].ToString());
            PincodeClient = new HttpClient();
            PincodeClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["PincodeServiceUrl"].ToString());
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PostRequest(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PutRequest(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteRequest(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
        public HttpResponseMessage GetPincodeResponse(string url)
        {
            return PincodeClient.GetAsync(url).Result;
        }
    }
}