using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.BLL.Services.Abstract;
using AutoMapper;
using NorthwindAPI.Models.Concrete.CategoryModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetListAsync();
            return result.Success ? Ok(_mapper.Map<List<GetCategoryVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetAsync(id);
            return result.Success ? Ok(_mapper.Map<GetCategoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddCategoryVM categoryModel)
        {
            var result = await _categoryService.InsertAsync(_mapper.Map<Category>(categoryModel));
            return result.Success ? Ok(_mapper.Map<AddCategoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryVM categoryModel)
        {
            var result = await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryModel));
            return result.Success ? Ok(_mapper.Map<UpdateCategoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteCategoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
    }
}
