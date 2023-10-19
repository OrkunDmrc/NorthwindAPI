using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<IResult<IEnumerable<OrderDetail>>> GetAllAsync()
        {
            return await _orderDetailRepository.GetAllAsync();
        }
        public async Task<IResult<OrderDetail>> InsertAsync(OrderDetail entity)
        {
            return await _orderDetailRepository.InsertAsync(entity);
        }
        public async Task<IResult<OrderDetail>> GetAsync(int id)
        {
            return await _orderDetailRepository.GetAsync(id);
        }
        public async Task<IResult<OrderDetail>> UpdateAsync(OrderDetail entity)
        {
            return await _orderDetailRepository.UpdateAsync(entity);
        }
        public async Task<IResult<OrderDetail>> DeleteAsync(int id)
        {
            return await _orderDetailRepository.DeleteAsync(id);
        }
        public async Task<IResult<IEnumerable<OrderDetail>>> GetAllByProductId(int id)
        {
            return await _orderDetailRepository.GetAllByProductId(id);
        }
        public async Task<IResult<IEnumerable<OrderDetail>>> GetAllByOrderIdProductIdAsync(int orderId, int productId)
        {
            return await _orderDetailRepository.GetAllByOrderIdProductIdAsync(orderId, productId);
        }
        public async Task<IResult<OrderDetail>> DeleteByOrderIdProductIdAsync(int orderId, int productId)
        {
            return await _orderDetailRepository.DeleteByOrderIdProductIdAsync(orderId, productId);
        }
        public async Task<IResult<IEnumerable<OrderDetail>>> GetAllByOrderId(int id)
        {
            return await _orderDetailRepository.GetAllByOrderId(id);
        }
    }
}
