using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFOrderDetailRepository : EFGenericRepository<OrderDetail, NorthwindContext>, IOrderDetailRepository
    {
        public async Task<IResult<List<OrderDetail>>> GetListByProductId(int id)
        {
            return await GetListAsync(od => od.ProductId == id);
        }
        public async Task<IResult<List<OrderDetail>>> GetListByOrderIdProductIdAsync(int orderId, int productId)
        {
            return await GetListAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }
        public async Task<IResult<OrderDetail>> DeleteByOrderIdProductIdAsync(int orderId, int productId)
        {
            return await DeleteAsync(od => od.OrderId == orderId && od.ProductId == productId);
        }

    }
}
