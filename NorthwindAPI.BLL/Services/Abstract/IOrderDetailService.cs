using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface IOrderDetailService : IService<OrderDetail>
    {
        Task<IResult<List<OrderDetail>>> GetListByProductId(int id);
        Task<IResult<List<OrderDetail>>> GetListByOrderIdProductIdAsync(int orderId, int productId);
        Task<IResult<OrderDetail>> DeleteByOrderIdProductIdAsync(int orderId, int productId);
    }
}
