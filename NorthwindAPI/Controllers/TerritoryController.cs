using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.EmployeModels;
using NorthwindAPI.Models.Concrete.Region;
using NorthwindAPI.Models.Concrete.TerritoryModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerritoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITerritoryService _territoryService;
        private readonly IRegionService _regionService;
        private readonly IEmployeeService _employeeService;
        public TerritoryController(IMapper mapper, ITerritoryService categoryService, IRegionService regionService, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _territoryService = categoryService;
            _regionService = regionService;
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("/Territories")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _territoryService.GetAllAsync();
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetTerritoryVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Territories/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _territoryService.GetAsync(id);
            return result.Success ? Ok(_mapper.Map<GetTerritoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddTerritoryVM model)
        {
            var result = await _territoryService.InsertAsync(_mapper.Map<Territory>(model));
            return result.Success ? Ok(_mapper.Map<AddTerritoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateTerritoryVM categoryModel)
        {
            var result = await _territoryService.UpdateAsync(_mapper.Map<Territory>(categoryModel));
            return result.Success ? Ok(_mapper.Map<UpdateTerritoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        [Route("/Territories/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _territoryService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteTerritoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Territories/{id}/Region")]
        public async Task<IActionResult> GetRegionByTeritoryId(string id)
        {
            var result = await _regionService.GetByTeritoryIdAsync(id);
            return result.Success ? Ok(_mapper.Map<GetRegionVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Territories/{id}/Employees")]
        public async Task<IActionResult> GetEmployeeByTeritoryId(string id)
        {
            var result = await _employeeService.GetAllByTeritoryIdAsync(id);
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetEmployeeVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
    }
}
