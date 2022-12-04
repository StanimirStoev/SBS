using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using SBS.Tools;

namespace SBS.Core.Services
{
    /// <summary>
    /// Service for Country
    /// </summary>
    public class CountryService : ICountryService
    {
        private readonly ISbsRepository repo;
        /// <summary>
        /// Init Service
        /// </summary>
        /// <param name="repo"></param>
        public CountryService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Add country in repository
        /// </summary>
        /// <param name="countryViewModel"></param>
        /// <returns></returns>
        public async Task Add(CountryViewModel countryViewModel)
        {
            Sanitizer.Sanitize(countryViewModel);
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

        /// <summary>
        /// Delete country from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets country from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get list of all Countries
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Updates an country
        /// </summary>
        /// <param name="countryViewModel"></param>
        /// <returns></returns>
        public async Task Update(CountryViewModel countryViewModel)
        {
            Sanitizer.Sanitize(countryViewModel);
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
