using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.ProductModels;
using NorthwindAPI.Models.Concrete.SuypplierModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;
        private readonly IProductService _productService;
        
        public SupplierController(IMapper mapper, ISupplierService supplierService, IProductService productService)
        {
            _mapper = mapper;
            _supplierService = supplierService;
            _productService = productService;
        }
        [HttpGet]
        [Route("/Suppliers")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _supplierService.GetAllAsync();
            return result.Success ? Ok(_mapper.Map<List<GetSupplierVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Suppliers/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _supplierService.GetAsync(id);
            return result.Success ? Ok(_mapper.Map<GetSupplierVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddSupplierVM model)
        {
            var result = await _supplierService.InsertAsync(_mapper.Map<Supplier>(model));
            return result.Success ? Ok(_mapper.Map<AddSupplierVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateSupplierVM model)
        {
            var result = await _supplierService.UpdateAsync(_mapper.Map<Supplier>(model));
            return result.Success ? Ok(_mapper.Map<UpdateSupplierVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpDelete]
        [Route("/Suppliers/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _supplierService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteSupplierVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Suppliers/{id}/Products")]
        public async Task<IActionResult> GetProductsBySupplierId(int id)
        {
            var result = await _productService.GetBySupplierIdAsync(id);
            return result.Success ? Ok(_mapper.Map<List<GetProductVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
    }
}
