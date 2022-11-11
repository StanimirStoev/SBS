using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;

namespace SBS.Core.Services
{
    public class CityService : ICityService
    {
        private readonly ISbsRepository repo;

        public CityService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(CityViewModelCreate cityViewModel)
        {
            var city = new City()
            {
                Name = cityViewModel.Name,
                CountryId = cityViewModel.CountryId
            };

            await repo.AddAsync(city);
            await repo.SaveChangesAsync();
        }

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

        public async Task Update(CityViewModelEdit cityViewModel)
        {
            var city = await repo.GetByIdAsync<City>(cityViewModel.Id);
            if (city != null)
            {
                city.Name = cityViewModel.Name;
                city.CountryId = cityViewModel.CountryId;  

                await repo.SaveChangesAsync();
            }
        }

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
