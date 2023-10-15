using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<IResult<Supplier>> DeleteAsync(int id)
        {
            return await _supplierRepository.DeleteAsync(id);
        }

        public async Task<IResult<Supplier>> GetAsync(int id)
        {
            return await _supplierRepository.GetAsync(id);
        }

        public async Task<IResult<IEnumerable<Supplier>>> GetAllAsync()
        {
            return await _supplierRepository.GetAllAsync();
        }

        public async Task<IResult<Supplier>> InsertAsync(Supplier entity)
        {
            return await _supplierRepository.InsertAsync(entity);
        }

        public async Task<IResult<Supplier>> UpdateAsync(Supplier entity)
        {
            return await _supplierRepository.UpdateAsync(entity);
        }

        public async Task<IResult<Supplier>> GetByProductId(int id)
        {
            return await _supplierRepository.GetByProductId(id);
        }
    }
}
