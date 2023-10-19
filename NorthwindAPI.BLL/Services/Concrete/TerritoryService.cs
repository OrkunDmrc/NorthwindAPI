using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class TerritoryService : ITerritoryService
    {
        private readonly ITerritoryRepository _territoryRepository;
        public TerritoryService(ITerritoryRepository territoryRepository)
        {
            _territoryRepository = territoryRepository;
        }

        public async Task<IResult<Territory>> DeleteAsync(string id)
        {
            return await _territoryRepository.DeleteAsync(id);
        }

        public async Task<IResult<Territory>> GetAsync(string id)
        {
            return await _territoryRepository.GetAsync(id);
        }

        public async Task<IResult<IEnumerable<Territory>>> GetAllAsync()
        {
            return await _territoryRepository.GetAllAsync();
        }

        public async Task<IResult<Territory>> InsertAsync(Territory entity)
        {
            return await _territoryRepository.InsertAsync(entity);
        }

        public async Task<IResult<Territory>> UpdateAsync(Territory entity)
        {
            return await _territoryRepository.UpdateAsync(entity);
        }

        public async Task<IResult<IEnumerable<Territory>>> GetAllByRegionIdAsync(int id)
        {
            return await _territoryRepository.GetAllByRegionIdAsync(id);
        }
    }
}
