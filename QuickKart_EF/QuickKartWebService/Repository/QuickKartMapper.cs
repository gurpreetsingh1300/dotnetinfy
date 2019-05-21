using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using QuickKartDataAccessLayer;

namespace QuickKartWebService.Repository
{
    public class QuickKartMapper<Source, Destination> 
        where Source : class
        where Destination : class
    {
        public QuickKartMapper()
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());

            //CreateMap<Product, Models.Product>();
            //CreateMap<Models.Product, Product>();

            //Mapper.Map<Product, Models.Product>(,);
            ////From entity to model
            //AutoMapper.Mapper.Map<Product, Models.Product>();
            ////From model to entity
            //Mapper.CreateMap<Models.Product, Product>();
        }
        public Destination Translate(Source obj)
        {
            return Mapper.Map<Destination>(obj);
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, Models.Product>();
            CreateMap<Models.Product, Product>();
    }
    }
}