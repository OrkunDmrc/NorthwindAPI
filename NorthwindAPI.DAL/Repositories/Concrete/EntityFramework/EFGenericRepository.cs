
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Core.Entities.Abstract;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.Core.Results.Concrete;
using NorthwindAPI.DAL.Repository.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFGenericRepository<T, C> : IGenericRepository<T> where T : class, IEntity where C : DbContext, new()
    {
        private IResult<T> _result;
        private IResult<List<T>> _resultList;
        public EFGenericRepository()
        {
            //todo it may be dependency injection
            _result = new Result<T>();
            _resultList = new Result<List<T>>();
        }
        public async Task<IResult<List<T>>> GetListAsync()
        {
            try
            {
                using (var context = new C())
                {
                    _resultList.Object = context.Set<T>().ToList();
                    _resultList.Success = true;
                    _resultList.ErrorMessage = null;
                }
            }
            catch (Exception ex)
            {
                _resultList.Success = false;
                _resultList.Object = null;
                _resultList.ErrorMessage = ex.Message;
            }
            return _resultList;
        }

        public async Task<IResult<T>> GetAsync(int id)
        {
            try
            {
                using (var context = new C())
                {
                    _result.Object = await context.Set<T>().FindAsync(id);
                    _result.Success = true;
                    _result.ErrorMessage = null;
                }
            }
            catch (Exception ex)
            {
                _result.Success = false;
                _result.Object = null;
                _result.ErrorMessage = ex.Message;
            }
            return _result;
        }

        public async Task<IResult<T>> InsertAsync(T entity)
        {
            try
            {
                using (var context = new C())
                {
                    var ent = await context.Set<T>().AddAsync(entity);
                    await context.SaveChangesAsync();
                    _result.Object = entity;
                    _result.Success = true;
                    _result.ErrorMessage = null;
                }
            }
            catch (Exception ex)
            {
                _result.Success = false;
                _result.Object = null;
                _result.ErrorMessage = ex.Message;
            }
            return _result;
        }

        public async Task<IResult<T>> UpdateAsync(T entity)
        {
            try
            {
                using (var context = new C())
                {
                    context.Set<T>().Update(entity);
                    await context.SaveChangesAsync();
                    _result.Object = entity;
                    _result.Success = true;
                    _result.ErrorMessage = null;
                }
            }
            catch (Exception ex)
            {
                _result.Success = false;
                _result.Object = null;
                _result.ErrorMessage = ex.Message;
            }
            return _result;
        }

        public async Task<IResult<T>> DeleteAsync(int id)
        {
            try
            {
                using (var context = new C())
                {
                    var entity = await context.Set<T>().FindAsync(id);
                    context.Set<T>().Remove(entity);
                    await context.SaveChangesAsync();
                    _result.Object = entity;
                    _result.Success = true;
                    _result.ErrorMessage = null;
                }
            }
            catch (Exception ex)
            {
                _result.Success = false;
                _result.Object = null;
                _result.ErrorMessage = ex.Message;
            }
            return _result;
        }

    }
}
