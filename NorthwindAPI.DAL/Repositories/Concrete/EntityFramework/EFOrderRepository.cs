using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFOrderRepository : EFGenericRepository<Order, int, NorthwindContext>, IOrderRepository
    {
        public async Task<IResult<IEnumerable<Order>>> GetAllByCustomerIdAsync(string id)
        {
            return await GetAllAsync(o => o.CustomerId == id);
        }

        public async Task<IResult<IEnumerable<Order>>> GetAllByEmployeeIdAsync(int id)
        {
            return await GetAllAsync(o => o.EmployeeId == id);
        }

        public async Task<IResult<IEnumerable<Order>>> GetAllByShipViaAsync(int id)
        {
            return await GetAllAsync(o => o.ShipVia == id);
        }
    }
}
