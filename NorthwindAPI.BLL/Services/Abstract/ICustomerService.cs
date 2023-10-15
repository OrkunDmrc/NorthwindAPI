using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface ICustomerService : IService<Customer, string>
    {
        Task<IResult<Customer>> GetByOrderId(int id);
       /* Task<IResult<Customer>> GetAsync(string id);
        Task<IResult<Customer>> DeleteAsync(string id);*/
    }
}
