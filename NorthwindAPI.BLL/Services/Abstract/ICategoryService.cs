
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface ICategoryService : IService<Category>
    {
        Task<IResult<Category>> GetByProductId(int id);
    }
}
