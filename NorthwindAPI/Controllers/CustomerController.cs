using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.CustomerModels;
using NorthwindAPI.Models.Concrete.OrderModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public CustomerController(IMapper mapper, ICustomerService customerService, IOrderService orderService)
        {
            _mapper = mapper;
            _customerService = customerService;
            _orderService = orderService;
        }
        [HttpGet]
        [Route("/Customers")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAllAsync();
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetCustomerVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Customers/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _customerService.GetAsync(id);
            return result.Success ? Ok(_mapper.Map<GetCustomerVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddCustomerVM model)
        {
            var result = await _customerService.InsertAsync(_mapper.Map<Customer>(model));
            return result.Success ? Ok(_mapper.Map<AddCustomerVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomerVM model)
        {
            var result = await _customerService.UpdateAsync(_mapper.Map<Customer>(model));
            return result.Success ? Ok(_mapper.Map<UpdateCustomerVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        [Route("/Customers/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _customerService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteCustomerVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Customers/{id}/Orders")]
        public async Task<IActionResult> GetOrdersByCustomerIdAsync(string id)
        {
            var result = await _orderService.GetAllByCustomerIdAsync(id);
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetOrderVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
    }
}
