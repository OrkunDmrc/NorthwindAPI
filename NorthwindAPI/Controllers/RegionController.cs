using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.Region;
using NorthwindAPI.Models.Concrete.TerritoryModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRegionService _regionService;
        private readonly ITerritoryService _territoryService;

        public RegionController(IMapper mapper, IRegionService regionService, ITerritoryService territoryService)
        {
            _mapper = mapper;
            _regionService = regionService;
            _territoryService = territoryService;
        }
        [HttpGet]
        [Route("/Regions")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _regionService.GetAllAsync();
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetRegionVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Regions/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _regionService.GetAsync(id);
            return result.Success ? Ok(_mapper.Map<GetRegionVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddRegionVM model)
        {
            var result = await _regionService.InsertAsync(_mapper.Map<Region>(model));
            return result.Success ? Ok(_mapper.Map<AddRegionVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateRegionVM categoryModel)
        {
            var result = await _regionService.UpdateAsync(_mapper.Map<Region>(categoryModel));
            return result.Success ? Ok(_mapper.Map<UpdateRegionVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        [Route("/Regions/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _regionService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteRegionVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Regions/{id}/Territories")]
        public async Task<IActionResult> GetTerritoriesByRegionId(int id)
        {
            var result = await _territoryService.GetAllByRegionIdAsync(id);
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetTerritoryVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }

    }
}
