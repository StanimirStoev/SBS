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
                    Name = store.Name,
                    Description = store.Description,
                    IsActive = store.IsActive,
                };
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

                await repo.SaveChangesAsync();
            }
        }
    }
}
