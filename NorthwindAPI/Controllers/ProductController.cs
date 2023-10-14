﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Models.Concrete.CategoryModels;
using NorthwindAPI.Models.Concrete.ProductModels;
using NorthwindAPI.Models.Concrete.SuypplierModels;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplyService;
        public ProductController(IMapper mapper, IProductService productService, ICategoryService categoryService, ISupplierService supplyService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
            _supplyService = supplyService;
        }
        [HttpGet]
        [Route("/Products")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetListAsync();
            return result.Success ? Ok (_mapper.Map<List<GetProductVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Products/{id}")]
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
        [Route("/Products/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            return result.Success ? Ok(_mapper.Map<DeleteProductVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Products/{id}/Category")]
        public async Task<IActionResult> GetCategoryByProductId(int id)
        {
            var result = await _categoryService.GetByProductId(id);
            return result.Success ? Ok(_mapper.Map<GetCategoryVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("/Products/{id}/Supplier")]
        public async Task<IActionResult> GetSupplyerByProductId(int id)
        {
            var result = await _supplyService.GetByProductId(id);
            return result.Success ? Ok(_mapper.Map<GetSupplierVM>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        /*[HttpGet]
        //category controller 
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var result = await _productService.GetByCategoryIdAsync(categoryId);
            return result.Success ? Ok(_mapper.Map<List<GetProductByCategoryIdVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        public async Task<IActionResult> GetListWithCategory()
        {
            var result = await _productService.GetListWithCategory();
            return result.Success ? Ok(_mapper.Map<List<GetProductWithCategoryVM>>(result.Object)) : BadRequest(result.ErrorMessage);
        }*/
    }

}
