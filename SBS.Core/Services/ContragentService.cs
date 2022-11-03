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

            await repo.AddAsync(contragent);

            foreach (AddressViewModel addressViewModel in contragentViewModel.Addresses)
            {
                //Country counry = await repo.GetByIdAsync<Country>(addressViewModel.CountryId);
                //City city = await repo.GetByIdAsync<City>(addressViewModel.CityId);
                contragent.Addresses.Add(new Address
                {
                    CountryId = addressViewModel.CountryId,
                    //Country = counry,
                    CityId = addressViewModel.CityId,
                    //City = city,
                    AddressLine1 = addressViewModel.AddressLine1,
                    AddressLine2 = addressViewModel.AddressLine2,
                });
            }

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
            var contragent = await repo.All<Contragent>()
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contragent != null)
            {
                model = new ContragentViewModel()
                {
                    Id = id,
                    FirstName = contragent.FirstName,
                    LastName = contragent.LastName,
                    IsClient = contragent.IsClient,
                    IsSupplier = contragent.IsSupplier,
                    VatNumber = contragent.VatNumber,
                    IsActive = contragent.IsActive,
                };
                foreach (Address address in contragent.Addresses)
                {
                    var cntry = await repo.GetByIdAsync<Country>(address.CountryId);
                    var cty = await repo.GetByIdAsync<City>(address.CityId);

                    model.Addresses.Add(new AddressViewModel()
                    {
                        Id = address.Id,
                        CountryId = address.CountryId,
                        Country = new CountryViewModel()
                        {
                            Id = cntry.Id,
                            Name = cntry.Name,
                            Code = cntry.Code,
                            IsEu = cntry.IsEu,
                            IsActive = cntry.IsActive
                        },
                        CityId = address.CityId,
                        City = new CityViewModel()
                        {
                            Id = cty.Id,
                            Name = cty.Name,
                            IsActive = cty.IsActive,
                        },
                        AddressLine1 = address.AddressLine1,
                        AddressLine2 = address.AddressLine2,
                        IsActive = address.IsActive,
                    });
                }
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

            var contragent = await repo.All<Contragent>()
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.Id == contragentViewModel.Id);
            if (contragent != null)
            {
                contragent.FirstName = contragentViewModel.FirstName;
                contragent.LastName = contragentViewModel.LastName;
                contragent.IsClient = contragentViewModel.IsClient;
                contragent.IsSupplier = contragentViewModel.IsSupplier;
                contragent.VatNumber = contragentViewModel.VatNumber;
                contragent.IsActive = contragentViewModel.IsActive;

                contragent.Addresses.Clear();
                foreach (var adrs in contragentViewModel.Addresses)
                {
                    contragent.Addresses.Add(new Address()
                    {
                        Id = adrs.Id,
                        CountryId = adrs.CountryId,
                        CityId = adrs.CityId,
                        AddressLine1 = adrs.AddressLine1,
                        AddressLine2 = adrs.AddressLine2,
                        IsActive = adrs.IsActive,
                    });
                }
                await repo.SaveChangesAsync();
            }
        }
    }
}
