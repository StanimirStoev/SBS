using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using SBS.Tools;

namespace SBS.Core.Services
{
    /// <summary>
    /// Service for City
    /// </summary>
    public class CityService : ICityService
    {
        private readonly ISbsRepository repo;
        /// <summary>
        /// Init service
        /// </summary>
        /// <param name="repo"></param>
        public CityService(ISbsRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// Add city in repository
        /// </summary>
        /// <param name="cityViewModel"></param>
        /// <returns></returns>
        public async Task Add(CityViewModelCreate cityViewModel)
        {
            Sanitizer.Sanitize(cityViewModel);
            var city = new City()
            {
                Name = cityViewModel.Name,
                CountryId = cityViewModel.CountryId
            };

            await repo.AddAsync(city);
            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// Delete city from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            var city = await repo.All<City>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (city != null)
            {
                city.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Gets city from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CityViewModel> Get(Guid id)
        {
            CityViewModel model = new CityViewModel();
            var city = await repo.GetByIdAsync<City>(id);


            if (city != null)
            {
                model = new CityViewModel()
                {
                    Id = city.Id,
                    Name = city.Name,
                    IsActive = city.IsActive,
                    CountryId = city.CountryId,
                };
            }
            return model;
        }
        /// <summary>
        /// Get list of all cities
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CityViewModel>> GetAll()
        {

            return await repo.AllReadonly<City>()
                .Where(c => c.IsActive)
                .Select(c => new CityViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    CountryId = c.CountryId,
                    Country = new CountryViewModel()
                    {
                        Id = c.Country.Id,
                        Name= c.Country.Name,
                        Code = c.Country.Code,
                        IsEu = c.Country.IsEu,
                    },
                }).ToListAsync();
        }
        /// <summary>
        /// Updates a city
        /// </summary>
        /// <param name="cityViewModel"></param>
        /// <returns></returns>
        public async Task Update(CityViewModelEdit cityViewModel)
        {
            Sanitizer.Sanitize(cityViewModel);
            var city = await repo.GetByIdAsync<City>(cityViewModel.Id);
            if (city != null)
            {
                city.Name = cityViewModel.Name;
                city.CountryId = cityViewModel.CountryId;  

                await repo.SaveChangesAsync();
            }
        }
        /// <summary>
        ///  Get list of all countries
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CountryViewModel>> GetAllCountries()
        {
            return await repo.AllReadonly<Country>()
                .Where(c => c.IsActive)
                .Select(c => new CountryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    IsEu = c.IsEu,
                    IsActive = c.IsActive,
                }).ToListAsync();
        }
        /// <summary>
        /// Get all cities for country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CityViewModel>> GetForCountry(Guid id)
        {
            return await repo.AllReadonly<City>()
             .Where(c => c.IsActive && c.CountryId == id)
             .Select(c => new CityViewModel()
             {
                 Id = c.Id,
                 Name = c.Name,
                 CountryId= c.CountryId,
                 IsActive = c.IsActive,
             }).ToListAsync();
        }
    }
}
