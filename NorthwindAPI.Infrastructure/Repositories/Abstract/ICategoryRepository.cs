using NorthwindAPI.Domain.Entities.Concrete;
using NorthwindAPI.Infrastructure.Repository.Abstract;

namespace NorthwindAPI.Infrastructure.Repositories.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
