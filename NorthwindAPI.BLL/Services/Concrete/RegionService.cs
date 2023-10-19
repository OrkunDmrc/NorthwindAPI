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
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }
        public async Task<IResult<Region>> DeleteAsync(int id)
        {
            return await _regionRepository.DeleteAsync(id);
        }

        public async Task<IResult<Region>> GetAsync(int id)
        {
            return await _regionRepository.GetAsync(id);
        }

        public async Task<IResult<IEnumerable<Region>>> GetAllAsync()
        {
            return await _regionRepository.GetAllAsync();
        }

        public async Task<IResult<Region>> InsertAsync(Region entity)
        {
            return await _regionRepository.InsertAsync(entity);
        }

        public async Task<IResult<Region>> UpdateAsync(Region entity)
        {
            return await _regionRepository.UpdateAsync(entity);
        }
    }
}
