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
        public async Task<IResult<List<Product>>> GetListAsync()
        {
            return await _productRepository.GetListAsync();
        }
        public async Task<IResult<Product>> InsertAsync(Product product)
        {
            return await _productRepository.InsertAsync(product);
        }
        public async Task<IResult<Product>> GetAsync(int id)
        {
            return await _productRepository.GetAsync(id);
        }
        public async Task<IResult<Product>> UpdateAsync(int id, Product product)
        {
            return await _productRepository.UpdateAsync(id, product);
        }
        public async Task<IResult<Product>> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
