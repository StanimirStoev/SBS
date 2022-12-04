using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using SBS.Tools;

namespace SBS.Core.Services
{
    /// <summary>
    /// Service for Address
    /// </summary>
    public class AddressService : IAddressService
    {
        private readonly ISbsRepository repo;
        /// <summary>
        /// Init Service
        /// </summary>
        /// <param name="repo"></param>
        public AddressService(ISbsRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// Add Address in repository
        /// </summary>
        /// <param name="addressViewModel"></param>
        /// <returns></returns>
        public async Task Add(AddressViewModel addressViewModel)
        {
            Sanitizer.Sanitize(addressViewModel);
            var address = new Address()
            {
                AddressLine1 = addressViewModel.AddressLine1,
                AddressLine2 = addressViewModel.AddressLine2,
                CityId = addressViewModel.CityId,
                CountryId = addressViewModel.CountryId,
                IsActive = addressViewModel.IsActive,
            };

            await repo.AddAsync(address);
            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// Delete address from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            var address = await repo.All<Address>()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (address != null)
            {
                address.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Gets address from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AddressViewModel> Get(Guid id)
        {
            AddressViewModel model = new AddressViewModel();
            var address = await repo.GetByIdAsync<Address>(id);

            if (address != null)
            {
                model = new AddressViewModel()
                {
                    Id = address.Id,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    Country = new CountryViewModel()
                    {
                        Id = address.CountryId,
                        //Code = address.Country.Code,
                        //IsEu = address.Country.IsEu,
                        //Name = address.Country.Name,
                    },
                    City = new CityViewModel()
                    {
                        Id = address.CityId,
                        //Name = address.City.Name,
                    },
                    IsActive = address.IsActive,
                };
            }
            return model;
        }
        /// <summary>
        /// Get list of all Addresses
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AddressViewModel>> GetAll()
        {
            return await repo.AllReadonly<Address>()
                .Where(a => a.IsActive)
                .Select(a => new AddressViewModel()
                {
                    Id = a.Id,
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    Country = new CountryViewModel()
                    {
                        Id = a.Country.Id,
                        Code = a.Country.Code,
                        IsEu = a.Country.IsEu,
                        Name = a.Country.Name,
                    },
                    City = new CityViewModel()
                    {
                        Id = a.City.Id,
                        Name = a.City.Name,
                    },
                    IsActive = a.IsActive,
                }).ToListAsync();
        }
        /// <summary>
        /// Updates an Address
        /// </summary>
        /// <param name="addressViewModel"></param>
        /// <returns></returns>
        public async Task Update(AddressViewModel addressViewModel)
        {
            Sanitizer.Sanitize(addressViewModel);
            var address = await repo.GetByIdAsync<Address>(addressViewModel.Id);
            if (address != null)
            {
                address.AddressLine1 = addressViewModel.AddressLine1;
                address.AddressLine2 = addressViewModel.AddressLine2;
                address.CityId = addressViewModel.CityId;
                address.CountryId = addressViewModel.CountryId;
                address.IsActive = addressViewModel.IsActive;

                await repo.SaveChangesAsync();
            }
        }
    }
}
