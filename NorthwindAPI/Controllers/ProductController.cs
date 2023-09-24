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
    }

}
