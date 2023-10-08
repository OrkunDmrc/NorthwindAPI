using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.ProductModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper, IProductService productService)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetListAsync();
            return result.Success ? Ok (_mapper.Map<List<GetProductVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.GetAsync(id);
            return result.Success ? Ok(_mapper.Map<GetProductVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddProductVM productVM)
        {
            var result =  await _productService.InsertAsync(_mapper.Map<Product>(productVM));
            return result.Success ? Ok(_mapper.Map<AddProductVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductVM productVM)
        {
            var result = await _productService.UpdateAsync(_mapper.Map<Product>(productVM));
            return result.Success ? Ok(_mapper.Map<UpdateProductVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteProductVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }

    }

}
