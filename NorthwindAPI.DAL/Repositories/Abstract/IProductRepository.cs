using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repository.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IResult<IEnumerable<Product>>> GetAllByCategoryIdAsync(int categoryId);
        Task<IResult<IEnumerable<Product>>> GetAllWithCategoryAsync();
        Task<IResult<IEnumerable<Product>>> GetAllBySupplierIdAsync(int id);
    }
}
