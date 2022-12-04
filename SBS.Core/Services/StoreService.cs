using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using SBS.Tools;

namespace SBS.Core.Services
{
    /// <summary>
    /// Service for Stores
    /// </summary>
    public class StoreService : IStoreService
    {
        private readonly ISbsRepository repo;

        /// <summary>
        /// Init service
        /// </summary>
        /// <param name="repo"></param>
        public StoreService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Add store in repository
        /// </summary>
        /// <param name="storeViewModel"></param>
        /// <returns></returns>
        public async Task Add(StoreViewModel storeViewModel)
        {
            Sanitizer.Sanitize(storeViewModel);
            var store = new Store()
            {
                Id = storeViewModel.Id,
                Name = storeViewModel.Name,
                Description=storeViewModel.Description,
            };
            if (storeViewModel.Address != null)
            {
                if (store.Address == null)
                {
                    store.Address = new Address();
                }

                store.AddressId = storeViewModel.AddressId;
                store.Address.CountryId = storeViewModel.Address.CountryId;
                store.Address.CityId = storeViewModel.Address.CityId;
                store.Address.AddressLine1 = storeViewModel.Address.AddressLine1;
                store.Address.AddressLine2 = storeViewModel.Address.AddressLine2;
            }
            else
            {
                if (store.Address != null || store.AddressId != null)
                {
                    store.Address.IsActive = false;
                }
            }

            await repo.AddAsync(store);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Store from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            var store = await repo.All<Store>()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (store != null)
            {
                store.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets store from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StoreViewModel> Get(Guid id)
        {
            StoreViewModel model = new StoreViewModel();
            var store = await repo.GetByIdAsync<Store>(id);

            if (store != null)
            {
                model = new StoreViewModel()
                {
                    Id=store.Id,
                    Name = store.Name,
                    Description = store.Description,
                    IsActive = store.IsActive,
                };
                if(store.AddressId != null)
                {
                    if(store.Address == null)
                    {
                        store.Address = await repo.All<Address>(a => a.Id == store.AddressId)
                            .Include(a => a.Country)
                            .FirstOrDefaultAsync();
                    }

                    var cntry = await repo.All<Country>()
                        .Include(c => c.Cities)
                        .FirstOrDefaultAsync(c => c.Id == store.Address.CountryId);
                    var cty = await repo.GetByIdAsync<City>(store.Address.CityId);

                    model.Address = new AddressViewModel()
                    {
                        Id = store.Address.Id,
                        City = new CityViewModel()
                        {
                            Id =cty.Id,
                            CountryId = cty.Id,
                            Name= cty.Name,
                            IsActive= cty.IsActive,
                        },
                        CityId = store.Address.CityId,
                        Country = new CountryViewModel()
                        {
                            Id = cntry.Id,
                            IsEu = cntry.IsEu,
                            Name = cntry.Name,
                            Code = cntry.Code,
                            Cities = cntry.Cities.Select(c => new CityViewModel()
                            {
                                Id = c.Id,
                                Name = c.Name,
                                CountryId = c.CountryId,
                                IsActive = c.IsActive
                            }).ToList(),
                            IsActive = store.Address.Country.IsActive,
                        },
                        CountryId = store.Address.CountryId,

                        AddressLine1 = store.Address.AddressLine1,
                        AddressLine2 = store.Address.AddressLine2,
                    };
                }
            }
            return model;
        }

        /// <summary>
        /// Get list of all stores
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StoreViewModel>> GetAll()
        {
            return await repo.AllReadonly<Store>()
                .Where(s => s.IsActive)
                .Select(s => new StoreViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    IsActive = s.IsActive,
                }).ToListAsync();
        }

        /// <summary>
        /// Get list of all stores that has 1 or more quantity in it, but exclude store with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StoreViewModel>> GetAllExcluded(Guid id)
        {
            return await repo.AllReadonly<Store>()
                .Where(s => s.IsActive && s.Id != id)
                .Select(s => new StoreViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    IsActive = s.IsActive,
                }).ToListAsync();
        }

        /// <summary>
        /// Get list of all stores that has 1 or more quantity in it
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StoreViewModel>> GetAllNotEmpty()
        {
            return await repo.AllReadonly<Store>()
                .Where(s => s.IsActive && s.PartidesInStores.Any(p => p.Qty > 0))
                .Select(s => new StoreViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    IsActive = s.IsActive,
                }).ToListAsync();
        }

        /// <summary>
        /// Updates an store
        /// </summary>
        /// <param name="storeViewModel"></param>
        /// <returns></returns>
        public async Task Update(StoreViewModel storeViewModel)
        {
            Sanitizer.Sanitize(storeViewModel);
            var store = await repo.GetByIdAsync<Store>(storeViewModel.Id);
            if (store != null)
            {
                store.Name = storeViewModel.Name;
                store.Description = storeViewModel.Description;
                store.IsActive = storeViewModel.IsActive;
                if(storeViewModel.Address != null)
                {
                    if(store.Address == null)
                    {
                        store.Address = new Address();
                    }

                    store.AddressId = storeViewModel.AddressId;
                    store.Address.CountryId = storeViewModel.Address.CountryId;
                    store.Address.CityId = storeViewModel.Address.CityId;
                    store.Address.AddressLine1 = storeViewModel.Address.AddressLine1;
                    store.Address.AddressLine2 = storeViewModel.Address.AddressLine2;
                }
                else
                {
                    if(store.Address != null || store.AddressId != null)
                    {
                        store.Address.IsActive = false;
                    }
                }

                await repo.SaveChangesAsync();
            }
        }
    }
}
