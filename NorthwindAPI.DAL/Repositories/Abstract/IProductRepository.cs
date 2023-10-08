using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repository.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IResult<List<Product>>> GetListByCategoryIdAsync(int categoryId);
        Task<IResult<List<Product>>> GetListWithCategoryAsync();
    }
}
