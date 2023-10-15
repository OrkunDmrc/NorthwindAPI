using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface ICustomerService : IService<Customer>
    {
        Task<IResult<Customer>> GetByOrderId(int id);
    }
}
