using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IResult<Category>> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IResult<Category>> GetAsync(int id)
        {
            return await _categoryRepository.GetAsync(id);
        }

        public async Task<IResult<IEnumerable<Category>>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<IResult<Category>> InsertAsync(Category entity)
        {
            return await _categoryRepository.InsertAsync(entity);
        }

        public async Task<IResult<Category>> UpdateAsync(Category entity)
        {
            return await _categoryRepository.UpdateAsync(entity);
        }

        public async Task<IResult<Category>> GetByProductIdAsync(int id)
        {
            return await _categoryRepository.GetByProductId(id);
        }
    }
}
