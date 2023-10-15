using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IResult<Order>> DeleteAsync(int id)
        {
            return await _orderRepository.DeleteAsync(id);
        }

        public async Task<IResult<Order>> GetAsync(int id)
        {
            return await _orderRepository.GetAsync(id);
        }

        public async Task<IResult<List<Order>>> GetListAsync()
        {
            return await _orderRepository.GetListAsync();
        }

        public async Task<IResult<Order>> InsertAsync(Order entity)
        {
            return await _orderRepository.InsertAsync(entity);
        }

        public async Task<IResult<Order>> UpdateAsync(Order entity)
        {
            return await _orderRepository.UpdateAsync(entity);
        }
    }
}
