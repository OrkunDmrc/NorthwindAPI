using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.CustomerModels;
using NorthwindAPI.Models.Concrete.EmployeModels;
using NorthwindAPI.Models.Concrete.OrderDetailModels;
using NorthwindAPI.Models.Concrete.OrderModels;
using NorthwindAPI.Models.Concrete.ShipperModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IShipperService _shipperService;
        private readonly IEmployeeService _employeeService;
        public OrderController(IMapper mapper, IOrderService orderService, ICustomerService customerService, IOrderDetailService orderDetailService, IShipperService shipperService, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _orderService = orderService;
            _customerService = customerService;
            _orderDetailService = orderDetailService;
            _shipperService = shipperService;
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("/Orders")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAllAsync();
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetOrderVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Orders/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _orderService.GetAsync(id);
            return result.Success ? Ok(_mapper.Map<GetOrderVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddOrderVM model)
        {
            var result = await _orderService.InsertAsync(_mapper.Map<Order>(model));
            return result.Success ? Ok(_mapper.Map<AddOrderVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateOrderVM model)
        {
            var result = await _orderService.UpdateAsync(_mapper.Map<Order>(model));
            return result.Success ? Ok(_mapper.Map<UpdateOrderVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        [Route("/Orders/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteOrderVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Orders/{id}/Customer")]
        public async Task<IActionResult> GetCustomerByOrderId(int id)
        {
            var result = await _customerService.GetByOrderId(id);
            return result.Success ? Ok(_mapper.Map<GetCustomerVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Orders/{id}/OrderDetails")]
        public async Task<IActionResult> GetOrderDetailsByOrderId(int id)
        {
            var result = await _orderDetailService.GetAllByOrderId(id);
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetOrderDetailVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Orders/{id}/Shipper")]
        public async Task<IActionResult> GetShipperByOrderId(int id)
        {
            var result = await _shipperService.GetByOrderId(id);
            return result.Success ? Ok(_mapper.Map<GetShipperVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Orders/{id}/Employee")]
        public async Task<IActionResult> GetEmployeeByOrderId(int id)
        {
            var result = await _employeeService.GetByOrderIdAsync(id);
            return result.Success ? Ok(_mapper.Map<GetEmployeeVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }

    }
}
