using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace QuickKartWebService.Repository
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }
    }
}