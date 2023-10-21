using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFShipperRepository : EFGenericRepository<Shipper, int, NorthwindContext>, IShipperRepository
    {
        public async Task<IResult<Shipper>> GetByOrderId(int id)
        {
            return await GetAsync(s => s.Orders.Any(o => o.OrderId == id));
        }
    }
}
