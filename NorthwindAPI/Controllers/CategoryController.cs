using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.BLL.Services.Abstract;
using AutoMapper;
using NorthwindAPI.Models.Concrete.CategoryModels;
using NorthwindAPI.Models.Concrete.ProductModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        
        public CategoryController(IMapper mapper, ICategoryService categoryService, IProductService productService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _productService = productService;
        }
        [HttpGet]
        [Route("/Categories")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            return result.Success ? Ok(_mapper.Map<IEnumerable<GetCategoryVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Categories/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetAsync(id);
            return result.Success ? Ok(_mapper.Map<GetCategoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddCategoryVM model)
        {
            var result = await _categoryService.InsertAsync(_mapper.Map<Category>(model));
            return result.Success ? Ok(_mapper.Map<AddCategoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryVM model)
        {
            var result = await _categoryService.UpdateAsync(_mapper.Map<Category>(model));
            return result.Success ? Ok(_mapper.Map<UpdateCategoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        [Route("/Categories/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteCategoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Categories/{id}/Products")]
        public async Task<IActionResult> GetProductsByCategoryId(int id)
        {
            var result = await _productService.GetByCategoryIdAsync(id);
            return result.Success ? Ok(_mapper.Map<List<GetProductVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
    }
}
