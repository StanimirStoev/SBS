using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;

namespace SBS.Core.Services
{
    public class ContragentService : IContragentService
    {
        private readonly ISbsRepository repo;

        public ContragentService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(ContragentViewModel contragentViewModel)
        {
            var contragent = new Contragent()
            {
                FirstName = contragentViewModel.FirstName,
                LastName = contragentViewModel.LastName,
                IsClient = contragentViewModel.IsClient,
                IsSupplier = contragentViewModel.IsSupplier,
                VatNumber = contragentViewModel.VatNumber,
                IsActive = contragentViewModel.IsActive,
            };

            foreach (AddressViewModel addressViewModel in contragentViewModel.Addresses)
            {
                contragent.Addresses.Add(new Address
                {
                    CountryId= addressViewModel.CountryId,
                    CityId = addressViewModel.CityId,
                    AddressLine1 = addressViewModel.AddressLine1,
                    AddressLine2 = addressViewModel.AddressLine2,
                });
            }
            await repo.AddAsync(contragent);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var contragent = await repo.All<Contragent>()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contragent != null)
            {
                contragent.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }

        public async Task<ContragentViewModel> Get(Guid id)
        {
            ContragentViewModel model = new ContragentViewModel();
            var contragent = await repo.GetByIdAsync<Contragent>(id);


            if (contragent != null)
            {
                model = new ContragentViewModel()
                {
                    FirstName = contragent.FirstName,
                    LastName = contragent.LastName,
                    IsClient = contragent.IsClient,
                    IsSupplier = contragent.IsSupplier,
                    VatNumber = contragent.VatNumber,
                    IsActive = contragent.IsActive,
                };
            }
            return model;
        }

        public async Task<IEnumerable<ContragentViewModel>> GetAll()
        {
            return await repo.AllReadonly<Contragent>()
                    .Where(c => c.IsActive)
                    .Select(c => new ContragentViewModel()
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        IsClient = c.IsClient,
                        IsSupplier = c.IsSupplier,
                        VatNumber = c.VatNumber,
                        IsActive = c.IsActive,
                    }).ToListAsync();
        }

        public async Task Update(ContragentViewModel contragentViewModel)
        {
            var contragent = await repo.GetByIdAsync<Contragent>(contragentViewModel.Id);
            if (contragent != null)
            {
                contragent.FirstName = contragentViewModel.FirstName;
                contragent.LastName = contragentViewModel.LastName;
                contragent.IsClient = contragentViewModel.IsClient;
                contragent.IsSupplier = contragentViewModel.IsSupplier;
                contragent.VatNumber = contragentViewModel.VatNumber;
                contragent.IsActive = contragentViewModel.IsActive;

                await repo.SaveChangesAsync();
            }
        }
    }
}
