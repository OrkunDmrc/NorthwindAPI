
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Core.Entities.Abstract;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.Core.Results.Concrete;
using NorthwindAPI.DAL.Repository.Abstract;
using System.Linq.Expressions;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFGenericRepository<T, C> : IGenericRepository<T> where T : class, IEntity where C : DbContext, new()
    {
        protected IResult<T> result;
        protected IResult<IEnumerable<T>> resultList;
        public EFGenericRepository()
        {
            //todo it may be dependency injection
            result = new Result<T>();
            resultList = new Result<IEnumerable<T>>();
        }
        public async Task<IResult<IEnumerable<T>>> GetAllAsync()
        {
            try
            {
                using var context = new C();
                return resultList.FillSuccessResult(context.Set<T>().AsEnumerable());
            }
            catch (Exception ex)
            {
                return resultList.FillUnsuccessResult(ex.Message);
            }
        }
        public async Task<IResult<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                using var context = new C();
                return resultList.FillSuccessResult(context.Set<T>().Where(filter).AsEnumerable());
            }
            catch (Exception ex)
            {
                return resultList.FillUnsuccessResult(ex.Message);
            }
            return resultList;
        }
        public async Task<IResult<T>> GetAsync(int id)
        {
            try
            {
                using var context = new C();
                return result.FillSuccessResult(await context.Set<T>().FindAsync(id));
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }
        public async Task<IResult<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                using var context = new C();
                return result.FillSuccessResult(await context.Set<T>().FirstOrDefaultAsync(filter));
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }
        public async Task<IResult<T>> InsertAsync(T entity)
        {
            try
            {
                using var context = new C();
                var ent = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return result.FillSuccessResult(entity);
                
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }

        public async Task<IResult<T>> UpdateAsync(T entity)
        {
            try
            {
                using var context = new C();
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return result.FillSuccessResult(entity);
                
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }

        public async Task<IResult<T>> DeleteAsync(int id)
        {
            try
            {
                using var context = new C();
                var entity = await context.Set<T>().FindAsync(id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return result.FillSuccessResult(entity);
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }

        public async Task<IResult<T>> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                using var context = new C();
                var entity = await context.Set<T>().FindAsync(filter);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return result.FillSuccessResult(entity);
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }

    }
}
