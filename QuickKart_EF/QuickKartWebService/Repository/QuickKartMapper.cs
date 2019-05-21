using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace QuickKartWebService.Repository
{
    public class QuickKartMapper<Source, Destination> 
        where Source : class
        where Destination : class
    {
        public QuickKartMapper()
        {
            //Mapper.Initialize(c => c.AddProfile<MappingProfile>());

            //CreateMap<Product, Models.Product>();
            //CreateMap<Models.Product, Product>();

            //Mapper.Map<Product, Models.Product>(,);
            ////From entity to model
            //AutoMapper.Mapper.Map<Product, Models.Product>();
            ////From model to entity
            //Mapper.CreateMap<Models.Product, Product>();
        }
        public static void Initialize()
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }
        public Destination Translate(Source obj)
        {
            return Mapper.Map<Destination>(obj);
        }
    }
}