using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetListAsync();
            return result.Success ? Ok(result.Object) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.GetAsync(id);
            return result.Success ? Ok(result.Object) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            var result =  await _productService.InsertAsync(product);
            return result.Success ? Ok(result.Object) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            var result = await _productService.UpdateAsync(product);
            return result.Success ? Ok(result.Object) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            return result.Success ? Ok(result.Object) : BadRequest(result.ErrorMessage);
        }

    }

}
