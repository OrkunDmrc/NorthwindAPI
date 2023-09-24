using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Application.Abstract;
using NorthwindAPI.Domain.Entities.Concrete;

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
        public async Task<List<Product>> GetAll()
        {
            var result = await _productService.GetListAsync();
            return result;
        }
        [HttpGet]
        public async Task<Product> Get(int id)
        {
            var result = await _productService.GetAsync(id);
            return result;
        }
        [HttpPost]
        public async Task Post(Product product)
        {
            await _productService.InsertAsync(product);
        }
        [HttpPut]
        public async Task Put(Product product)
        {
            await _productService.UpdateAsync(product.ProductID, product);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _productService.DeleteAsync(await _productService.GetAsync(id));
        }

    }

}
