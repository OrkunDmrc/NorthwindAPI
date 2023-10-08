using AutoMapper;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.Category;
using NorthwindAPI.Models.Concrete.ProductModels;

namespace NorthwindAPI.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<Product, GetProductModel>().ForMember(p => p.ProductId, gp => gp.MapFrom(x => x.ProductId));
            //CreateMap<Product, GetProductModel>().IncludeMembers(x => x.ProductId);
            #region Product
            CreateMap<Product, GetProductVM>();
            CreateMap<GetProductVM, Product>();
            CreateMap<Product, AddProductVM>();
            CreateMap<AddProductVM, Product>();
            CreateMap<Product, UpdateProductVM>();
            CreateMap<UpdateProductVM, Product>();
            CreateMap<Product, DeleteProductVM>();
            CreateMap<DeleteProductVM, Product>();
            CreateMap<Product, GetProductByCategoryIdVM>();
            CreateMap<GetProductByCategoryIdVM, Product>();
            CreateMap<Product, GetProductWithCategoryVM>();
            CreateMap<GetProductWithCategoryVM, Product>();
            #endregion

            #region Category
            CreateMap<Category, GetCategoryVM>();
            CreateMap<GetCategoryVM, Category>();
            #endregion


        }
    }
}
