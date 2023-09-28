using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.BLL.Services.Abstract;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetListAsync();
            return result.Success ? Ok(result.Object) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetAsync(id);
            return result.Success ? Ok(result.Object) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            var result = await _categoryService.InsertAsync(category);
            return result.Success ? Ok(result.Object) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Category category)
        {
            var result = await _categoryService.UpdateAsync(category.CategoryID, category);
            return result.Success ? Ok(result.Object) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return result.Success ? Ok(result.Object) : BadRequest(result.ErrorMessage);
        }
    }
}
