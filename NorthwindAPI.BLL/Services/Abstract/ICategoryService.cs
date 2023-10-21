
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface ICategoryService : IService<Category, int>
    {
        Task<IResult<Category>> GetByProductIdAsync(int id);
    }
}
