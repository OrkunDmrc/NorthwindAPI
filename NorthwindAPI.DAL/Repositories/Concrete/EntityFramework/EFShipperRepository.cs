using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFShipperRepository : EFGenericRepository<Shipper, int, NorthwindContext>, IShipperRepository
    {
        public async Task<IResult<Shipper>> GetAllByOrderId(int id)
        {
            try
            {
                using (var context = new NorthwindContext())
                {
                    var queryResult = await(from s in context.Shippers
                                            join o in context.Orders on s.ShipperId equals o.ShipVia
                                            where o.OrderId == id
                                            select s).FirstOrDefaultAsync();
                    return result.FillSuccessResult(queryResult);
                }
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }
    }
}
