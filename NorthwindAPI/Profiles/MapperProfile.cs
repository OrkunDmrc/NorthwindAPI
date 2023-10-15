using AutoMapper;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.CategoryModels;
using NorthwindAPI.Models.Concrete.OrderModels;
using NorthwindAPI.Models.Concrete.OrderDetailModels;
using NorthwindAPI.Models.Concrete.ProductModels;
using NorthwindAPI.Models.Concrete.SuypplierModels;
using NorthwindAPI.Models.Concrete.CustomerModels;

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
            CreateMap<Category, DeleteCategoryVM>();
            CreateMap<DeleteCategoryVM, Category>();
            CreateMap<Category, UpdateCategoryVM>();
            CreateMap<UpdateCategoryVM, Category>();
            CreateMap<Category, AddCategoryVM>();
            CreateMap<AddCategoryVM, Category>();
            #endregion

            #region Customer
            CreateMap<Customer, GetCustomerVM>();
            CreateMap<GetCustomerVM, Customer>();
            CreateMap<Customer, DeleteCustomerVM>();
            CreateMap<DeleteCustomerVM, Customer>();
            CreateMap<Customer, UpdateCustomerVM>();
            CreateMap<UpdateCustomerVM, Customer>();
            CreateMap<Customer, AddCustomerVM>();
            CreateMap<AddCustomerVM, Customer>();
            #endregion

            #region Supplier
            CreateMap<Supplier, GetSupplierVM>();
            CreateMap<GetSupplierVM, Supplier>();
            CreateMap<Supplier, DeleteSupplierVM>();
            CreateMap<DeleteSupplierVM, Supplier>();
            CreateMap<Supplier, UpdateSupplierVM>();
            CreateMap<UpdateSupplierVM, Supplier>();
            CreateMap<Supplier, AddSupplierVM>();
            CreateMap<AddSupplierVM, Supplier>();
            #endregion

            #region Order
            CreateMap<Order, GetOrderVM>();
            CreateMap<GetOrderVM, Order>();
            CreateMap<Order, DeleteOrderVM>();
            CreateMap<DeleteOrderVM, Order>();
            CreateMap<Order, UpdateOrderVM>();
            CreateMap<UpdateOrderVM, Order>();
            CreateMap<Order, AddOrderVM>();
            CreateMap<AddOrderVM, Order>();
            #endregion

            #region OrderDetail
            CreateMap<OrderDetail, GetOrderDetailVM>();
            CreateMap<GetOrderDetailVM, OrderDetail>();
            CreateMap<OrderDetail, DeleteOrderDetailVM>();
            CreateMap<DeleteOrderDetailVM, OrderDetail>();
            CreateMap<OrderDetail, UpdateOrderDetailVM>();
            CreateMap<UpdateOrderDetailVM, OrderDetail>();
            CreateMap<OrderDetail, AddOrderDetailVM>();
            CreateMap<AddOrderDetailVM, OrderDetail>();
            #endregion


        }
    }
}
