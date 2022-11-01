using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;

namespace SBS.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly ISbsRepository repo;

        public CountryService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(CountryViewModel countryViewModel)
        {
            var country = new Country()
            {
                Name = countryViewModel.Name,
                Code = countryViewModel.Code,
                IsEu = countryViewModel.IsEu,
                IsActive = countryViewModel.IsActive,
            };

            await repo.AddAsync(country);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var country = await repo.All<Country>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (country != null)
            {
                country.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }

        public async Task<CountryViewModel> Get(Guid id)
        {
            CountryViewModel model = new CountryViewModel();
            var country = await repo.GetByIdAsync<Country>(id);


            if (country != null)
            {
                model = new CountryViewModel()
                {
                    Id = country.Id,
                    Name = country.Name,
                    IsEu = country.IsEu,
                    IsActive = country.IsActive,
                    Code = country.Code,
                };
            }
            return model;
        }

        public async Task<IEnumerable<CountryViewModel>> GetAll()
        {
            return await repo.AllReadonly<Country>()
                .Where(c => c.IsActive)
                .Select(c => new CountryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    Code = c.Code,
                    IsEu = c.IsEu,
                }).ToListAsync();
        }

        public async Task Update(CountryViewModel countryViewModel)
        {
            var country = await repo.GetByIdAsync<Country>(countryViewModel.Id);
            if (country != null)
            {
                country.Name = countryViewModel.Name;
                country.IsEu = countryViewModel.IsEu;
                country.Code = countryViewModel.Code;
                country.IsActive = countryViewModel.IsActive;

                await repo.SaveChangesAsync();
            }
        }
    }
}
