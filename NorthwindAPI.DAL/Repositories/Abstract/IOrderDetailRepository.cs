using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail, int>
    {
        Task<IResult<IEnumerable<OrderDetail>>> GetAllByProductId(int id);
        Task<IResult<IEnumerable<OrderDetail>>> GetAllByOrderIdProductIdAsync(int orderId, int productId);
        Task<IResult<OrderDetail>> DeleteByOrderIdProductIdAsync(int orderId, int productId);
        Task<IResult<IEnumerable<OrderDetail>>> GetAllByOrderId(int id);
    }
}
