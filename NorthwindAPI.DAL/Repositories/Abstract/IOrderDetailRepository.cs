using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repository.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail, int>
    {
        Task<IResult<IEnumerable<OrderDetail>>> GetAllByProductId(int id);
        Task<IResult<IEnumerable<OrderDetail>>> GetListByOrderIdProductIdAsync(int orderId, int productId);
        Task<IResult<OrderDetail>> DeleteByOrderIdProductIdAsync(int orderId, int productId);
        Task<IResult<IEnumerable<OrderDetail>>> GetAllByOrderId(int id);
    }
}
