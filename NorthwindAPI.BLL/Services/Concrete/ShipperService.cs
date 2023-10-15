using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        public ShipperService(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }
        public async Task<IResult<Shipper>> DeleteAsync(int id)
        {
            return await _shipperRepository.DeleteAsync(id);
        }

        public async Task<IResult<Shipper>> GetByOrderId(int id)
        {
            return await _shipperRepository.GetAllByOrderId(id);
        }

        public async Task<IResult<Shipper>> GetAsync(int id)
        {
            return await _shipperRepository.GetAsync(id);
        }

        public async Task<IResult<IEnumerable<Shipper>>> GetAllAsync()
        {
            return await _shipperRepository.GetAllAsync();
        }

        public async Task<IResult<Shipper>> InsertAsync(Shipper entity)
        {
            return await _shipperRepository.InsertAsync(entity);
        }

        public async Task<IResult<Shipper>> UpdateAsync(Shipper entity)
        {
            return await _shipperRepository.UpdateAsync(entity);
        }
    }
}
