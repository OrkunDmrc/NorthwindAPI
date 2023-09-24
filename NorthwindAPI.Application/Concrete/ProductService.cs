using NorthwindAPI.Application.Abstract;
using NorthwindAPI.Domain.Entities.Concrete;
using NorthwindAPI.Infrastructure.Repositories.Abstract;

namespace NorthwindAPI.Application.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> GetListAsync()
        {
            return await _productRepository.GetListAsync();
        }
        public async Task<Product> InsertAsync(Product product)
        {
            return await _productRepository.InsertAsync(product);
        }
        public async Task<Product> GetAsync(int id)
        {
            return await _productRepository.GetAsync(id);
        }
        public async Task<Product> UpdateAsync(int id, Product product)
        {
            return await _productRepository.UpdateAsync(id, product);
        }
        public async Task DeleteAsync(Product product)
        {
            await _productRepository.DeleteAsync(product);
        }
    }
}
