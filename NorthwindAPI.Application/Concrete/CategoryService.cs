using NorthwindAPI.Application.Abstract;
using NorthwindAPI.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Application.Concrete
{
    public class CategoryService : ICategoryService
    {
        public Task DeleteAsync(Category product)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> InsertAsync(Category product)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateAsync(int id, Category product)
        {
            throw new NotImplementedException();
        }
    }
}
