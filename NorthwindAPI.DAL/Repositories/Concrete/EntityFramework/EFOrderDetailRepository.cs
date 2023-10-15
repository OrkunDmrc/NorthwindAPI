using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFOrderDetailRepository : EFGenericRepository<OrderDetail, NorthwindContext>, IOrderDetailRepository
    {
        public async Task<IResult<IEnumerable<OrderDetail>>> GetAllByProductId(int id)
        {
            return await GetAllAsync(od => od.ProductId == id);
        }
        public async Task<IResult<IEnumerable<OrderDetail>>> GetListByOrderIdProductIdAsync(int orderId, int productId)
        {
            return await GetAllAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }
        public async Task<IResult<OrderDetail>> DeleteByOrderIdProductIdAsync(int orderId, int productId)
        {
            return await DeleteAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }
        public async Task<IResult<IEnumerable<OrderDetail>>> GetAllByOrderId(int id)
        {
            return await GetAllAsync(od => od.OrderId == id);
        }
    }
}
