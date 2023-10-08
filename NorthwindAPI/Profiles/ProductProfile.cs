using AutoMapper;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.ProductModels;

namespace NorthwindAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //CreateMap<Product, GetProductModel>().ForMember(p => p.ProductId, gp => gp.MapFrom(x => x.ProductId));
            //CreateMap<Product, GetProductModel>().IncludeMembers(x => x.ProductId);
            CreateMap<Product, GetProductVM>();
            CreateMap<GetProductVM, Product>();
            CreateMap<Product, AddProductVM>();
            CreateMap<AddProductVM, Product>();
            CreateMap<Product, UpdateProductVM>();
            CreateMap<UpdateProductVM, Product>();
            CreateMap<Product, DeleteProductVM>();
            CreateMap<DeleteProductVM, Product>();
        }
    }
}
