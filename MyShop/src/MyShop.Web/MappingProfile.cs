using AutoMapper;
using MyShop.Core.CategoryAggregate;
using MyShop.Core.ProductAggregate;
using MyShop.Web.Endpoints.CategoryEndpoints;
using MyShop.Web.Endpoints.ProductEndpoints;

namespace MyShop.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CreateCategoryResponse>();
            CreateMap<Category, GetCategoryByIdResponse>();
            CreateMap<Category, CategoryRecord>();

            CreateMap<Product, CreateProductResponse>();
            CreateMap<Product, GetProductByIdResponse>();
            CreateMap<Product, ProductRecord>();

        }
    }
}
