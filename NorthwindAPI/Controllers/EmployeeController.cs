using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.EmployeModels;
using NorthwindAPI.Models.Concrete.TerritoryModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeService;
        private readonly IOrderService _orderService;
        private readonly ITerritoryService _territoryService;

        public EmployeeController(IMapper mapper, IEmployeeService employeeService, IOrderService orderService, ITerritoryService territoryService)
        {
            _mapper = mapper;
            _employeService = employeeService;
            _orderService = orderService;
            _territoryService = territoryService;
        }
        [HttpGet]
        [Route("/Employees")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeService.GetAllAsync();
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetEmployeeVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Employees/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeService.GetAsync(id);
            return result.Success ? Ok(_mapper.Map<GetEmployeeVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddEmployeeVM model)
        {
            var result = await _employeService.InsertAsync(_mapper.Map<Employee>(model));
            return result.Success ? Ok(_mapper.Map<AddEmployeeVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateEmployeeVM model)
        {
            var result = await _employeService.UpdateAsync(_mapper.Map<Employee>(model));
            return result.Success ? Ok(_mapper.Map<UpdateEmployeeVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        [Route("/Employees/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteEmployeeVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Employees/{id}/Orders")]
        public async Task<IActionResult> GetOrdersByEmployeeId(int id)
        {
            var result = await _orderService.GetAllByEmployeeIdAsync(id);
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetEmployeeVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Employees/{id}/Territories")]
        public async Task<IActionResult> GetTerritoriesByEmployeeId(int id)
        {
            var result = await _territoryService.GetAllByEmployeeIdAsync(id);
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetTerritoryVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
    }
}
