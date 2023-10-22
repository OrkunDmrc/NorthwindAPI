using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IResult<IEnumerable<Product>>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }
        public async Task<IResult<Product>> InsertAsync(Product product)
        {
            return await _productRepository.InsertAsync(product);
        }
        public async Task<IResult<Product>> GetAsync(int id)
        {
            return await _productRepository.GetAsync(id);
        }
        public async Task<IResult<Product>> UpdateAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }
        public async Task<IResult<Product>> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
        public async Task<IResult<IEnumerable<Product>>> GetByCategoryIdAsync(int id)
        {
            return await _productRepository.GetAllByCategoryIdAsync(id);
        }
        public async Task<IResult<IEnumerable<Product>>> GetBySupplierIdAsync(int id)
        {
            return await _productRepository.GetAllBySupplierIdAsync(id);
        }
    }
}
