using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface ISupplierService : IService<Supplier>
    {
        Task<IResult<Supplier>> GetByProductId(int id);
    }
}
