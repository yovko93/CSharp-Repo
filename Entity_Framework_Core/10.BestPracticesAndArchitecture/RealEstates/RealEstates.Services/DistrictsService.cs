using System.Linq;
using RealEstates.Data;
using System.Collections.Generic;
using RealEstates.Services.Models;
using AutoMapper.QueryableExtensions;

namespace RealEstates.Services
{
    public class DistrictsService : BaseService, IDistrictsService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DistrictInfoDto> GetMostExepnsiveDistricts(int count)
        {
            var districts = dbContext.Districts
                .ProjectTo<DistrictInfoDto>(this.Mapper.ConfigurationProvider)
                .OrderByDescending(x => x.AveragePricePerSquareMeter)
                .Take(count)
                .ToList();

            return districts;
        }
    }
}
