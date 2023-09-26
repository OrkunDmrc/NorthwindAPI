using NorthwindAPI.Application.Abstract;
using NorthwindAPI.Domain.Entities.Concrete;
using NorthwindAPI.Domain.Results.Abstract;
using NorthwindAPI.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Application.Concrete
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

        public async Task<IResult<List<Category>>> GetListAsync()
        {
            return await _categoryRepository.GetListAsync();
        }

        public async Task<IResult<Category>> InsertAsync(Category entity)
        {
            return await _categoryRepository.InsertAsync(entity);
        }

        public async Task<IResult<Category>> UpdateAsync(int id, Category entity)
        {
            return await _categoryRepository.UpdateAsync(id, entity);
        }
    }
}
