using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;

namespace SBS.Core.Services
{
    public class StoreService : IStoreService
    {
        private readonly ISbsRepository repo;

        public StoreService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(StoreViewModel storeViewModel)
        {
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
                if(store.AddressId != null || store.Address != null)
                {
                    if(store.Address == null)
                    {
                        store.Address = await repo.GetByIdAsync<Address>(store.AddressId);
                    }
                    model.Address = new AddressViewModel()
                    {
                        Id = store.Address.Id,
                        CityId = store.Address.CityId,
                        CountryId = store.Address.CountryId,
                        AddressLine1 = store.Address.AddressLine1,
                        AddressLine2 = store.Address.AddressLine2,
                    };
                }
            }
            return model;
        }

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

        public async Task Update(StoreViewModel storeViewModel)
        {
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
