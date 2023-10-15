using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.ShipperModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipperController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShipperService _shipperService;
        private readonly IOrderService _orderService;
        public ShipperController(IMapper mapper, IShipperService productService, IOrderService orderService)
        {
            _mapper = mapper;
            _shipperService = productService;
            _orderService = orderService;
        }
        [HttpGet]
        [Route("/Shippers")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _shipperService.GetAllAsync();
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetShipperVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Shippers/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _shipperService.GetAsync(id);
            return result.Success ? Ok(_mapper.Map<GetShipperVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddShipperVM model)
        {
            var result = await _shipperService.InsertAsync(_mapper.Map<Shipper>(model));
            return result.Success ? Ok(_mapper.Map<AddShipperVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateShipperVM categoryModel)
        {
            var result = await _shipperService.UpdateAsync(_mapper.Map<Shipper>(categoryModel));
            return result.Success ? Ok(_mapper.Map<UpdateShipperVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        [Route("/Shippers/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _shipperService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteShipperVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Shippers/{id}/Orders")]
        public async Task<IActionResult> GetOrdersByShipperId(int id)
        {
            var result = await _orderService.GetAllByShipViaAsync(id);
            return result.Success ? Ok(_mapper.Map<GetShipperVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }

    }
}
