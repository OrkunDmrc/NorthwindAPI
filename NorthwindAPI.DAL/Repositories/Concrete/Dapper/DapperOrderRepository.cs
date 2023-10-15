using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperOrderRepository : DapperGenericRepository<Order, int>, IOrderRepository
    {
        public async Task<IResult<IEnumerable<Order>>> GetAllByCustomerIdAsync(string id)
        {
            string query = $"SELECT * FROM {GetTableName()} where CustomerId = '{id}'";
            return await QueryListAsync(query);
        }

        public async Task<IResult<IEnumerable<Order>>> GetAllByShipViaAsync(int id)
        {
            string query = $"SELECT * FROM {GetTableName()} where ShipVia = {id}";
            return await QueryListAsync(query);
        }
    }
}
