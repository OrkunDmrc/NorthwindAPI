using NorthwindAPI.Core.Entities.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface IProductService : IService<Product>
    {
        Task<IResult<IEnumerable<Product>>> GetByCategoryIdAsync(int categoryId);
        Task<IResult<IEnumerable<Product>>> GetListWithCategory();
        Task<IResult<IEnumerable<Product>>> GetBySupplierIdAsync(int id);
    }
}
