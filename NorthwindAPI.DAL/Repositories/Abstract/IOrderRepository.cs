using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order, int>
    {
        Task<IResult<IEnumerable<Order>>> GetAllByShipViaAsync(int id);
        Task<IResult<IEnumerable<Order>>> GetAllByCustomerIdAsync(string id);
        Task<IResult<IEnumerable<Order>>> GetAllByEmployeeIdAsync(int id);
    }
}
