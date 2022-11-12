using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using System.Linq;

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
                contragent.Addresses.Add(new Address
                {
                    CountryId = addressViewModel.CountryId,
                    CityId = addressViewModel.CityId,
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
                    //var cntry = await repo.GetByIdAsync<Country>(address.CountryId);
                    var cntry = await repo.All<Country>()
                        .Include(c => c.Cities)
                        .FirstOrDefaultAsync(c => c.Id == address.CountryId);
                    var cty = await repo.GetByIdAsync<City>(address.CityId);

                    model.Addresses.Add(new AddressViewModel()
                    {
                        Id = address.Id,
                        CountryId = address.CountryId,
                        Country = new CountryViewModel()
                        {
                            Id = address.CountryId,
                            Name = cntry.Name,
                            Code = cntry.Code,
                            IsEu = cntry.IsEu,
                            IsActive = cntry.IsActive,
                            Cities = cntry.Cities.Select(c => new CityViewModel()
                            {
                                Id=c.Id,
                                Name=c.Name,
                                CountryId = c.CountryId,
                                IsActive = c.IsActive
                            }).ToList()
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

                List<Guid> deletedIds = new List<Guid>();
                foreach (var adrs in contragentViewModel.Addresses)
                {
                    Address address = contragent.Addresses.FirstOrDefault(a => a.Id == adrs.Id);
                    if (address != null)
                    {
                        if(adrs.IsActive)
                        {
                            address.AddressLine1 = adrs.AddressLine1;
                            address.AddressLine2 = adrs.AddressLine2;
                            address.CityId = adrs.CityId;
                            address.CountryId = adrs.CountryId;
                        }
                        else
                        {
                            deletedIds.Add(adrs.Id);
                        }
                    }
                    else
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
                }

                for(int i = contragent.Addresses.Count -1; i >= 0 ; i--)
                {
                    if (deletedIds.Contains(contragent.Addresses[i].Id))
                    {
                        contragent.Addresses.Remove(contragent.Addresses[i]);
                    }
                }

                await repo.SaveChangesAsync();
            }
        }
    }
}
