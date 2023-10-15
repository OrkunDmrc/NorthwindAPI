using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.OrderDetailModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IMapper mapper, IOrderDetailService orderDetailService)
        {
            _mapper = mapper;
            _orderDetailService = orderDetailService;
        }
        [HttpGet]
        [Route("/OrderDetails")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderDetailService.GetListAsync();
            return result.Success ? Ok(_mapper.Map<List<GetOrderDetailVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/OrderDetails/{orderId}&{productId}")]
        public async Task<IActionResult> Get(int orderId, int productId)
        {
            var result = await _orderDetailService.GetListByOrderIdProductIdAsync(orderId, productId);
            return result.Success ? Ok(_mapper.Map<List<GetOrderDetailVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        /*[HttpPost]
        public async Task<IActionResult> Post(AddOrderDetailVM model)
        {
            var result = await _orderDetailService.InsertAsync(_mapper.Map<OrderDetail>(model));
            return result.Success ? Ok(_mapper.Map<AddOrderDetailVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateOrderDetailVM model)
        {
            var result = await _orderDetailService.UpdateAsync(_mapper.Map<OrderDetail>(model));
            return result.Success ? Ok(_mapper.Map<UpdateOrderDetailVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }*/
        [HttpDelete]
        [Route("/OrderDetails/{orderId}&{productId}")]
        public async Task<IActionResult> Delete(int orderId, int productId)
        {
            var result = await _orderDetailService.DeleteByOrderIdProductIdAsync(orderId, productId);
            return result.Success ? Ok(_mapper.Map<DeleteOrderDetailVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
    }
}
