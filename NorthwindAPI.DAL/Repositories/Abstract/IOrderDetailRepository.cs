using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repository.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        Task<IResult<List<OrderDetail>>> GetListByProductId(int id);
        Task<IResult<List<OrderDetail>>> GetListByOrderIdProductIdAsync(int orderId, int productId);
        Task<IResult<OrderDetail>> DeleteByOrderIdProductIdAsync(int orderId, int productId);
    }
}
