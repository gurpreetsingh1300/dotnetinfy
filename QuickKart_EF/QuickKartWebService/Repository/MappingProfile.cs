using AutoMapper;
using QuickKartDataAccessLayer;

namespace QuickKartWebService.Repository
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, Models.Product>();
            CreateMap<Models.Product, Product>();
    }
    }
}