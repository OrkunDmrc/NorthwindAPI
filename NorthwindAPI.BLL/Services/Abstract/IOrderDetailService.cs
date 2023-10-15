using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface IOrderDetailService : IService<OrderDetail, int>
    {
        Task<IResult<IEnumerable<OrderDetail>>> GetAllByProductId(int id);
        Task<IResult<IEnumerable<OrderDetail>>> GetAllByOrderIdProductIdAsync(int orderId, int productId);
        Task<IResult<OrderDetail>> DeleteByOrderIdProductIdAsync(int orderId, int productId);
        Task<IResult<IEnumerable<OrderDetail>>> GetAllByOrderId(int id);
    }
}
