using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperOrderDetailRepository : DapperGenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public async Task<IResult<IEnumerable<OrderDetail>>> GetAllByProductId(int id)
        {
            var query = $"SELECT * FROM {GetTableName()} where ProductID = {id}";
            return await QueryListAsync(query);
        }
        public async Task<IResult<IEnumerable<OrderDetail>>> GetListByOrderIdProductIdAsync(int orderId, int productId)
        {
            var query = $"SELECT * FROM {GetTableName()} where OrderID = {orderId} and ProductID = {productId}";
            return await QueryListAsync(query);
        }
        public async Task<IResult<OrderDetail>> DeleteByOrderIdProductIdAsync(int orderId, int productId)
        {
            var query = $"DELETE FROM {GetTableName()} where OrderID = {orderId} and ProductID = {productId}";
            return await ExecuteAsync(query, null);
        }
        public async Task<IResult<IEnumerable<OrderDetail>>> GetAllByOrderId(int id)
        {
            var query = $"SELECT * FROM {GetTableName()} where OrderId = {id}";
            return await QueryListAsync(query);
        }
    }
}
