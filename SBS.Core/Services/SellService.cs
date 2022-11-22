using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Services
{
    public class SellService : ISellService
    {
        private readonly ISbsRepository repo;

        public SellService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(SellViewModel viewModel)
        {
            var sell = new Sell()
            {
                Id = viewModel.Id,
                CreateDatetime = viewModel.CreateDatetime ?? DateTime.Now,
                ContragentId = viewModel.ContragentId,
                StoreId = viewModel.StoreId,
                IsActive = viewModel.IsActive,
            };
            foreach (SellDetailViewModel detailViewModel in viewModel.Details)
            {
                sell.Details.Add(new SellDetail()
                {
                    Id = detailViewModel.Id,
                    ArticleId = detailViewModel.ArticleId,
                    UnitId = detailViewModel.UnitId,
                    Price = detailViewModel.Price,
                    Qty = detailViewModel.Qty,
                    Sell = sell,
                    SellId= detailViewModel.SellId,
                    IsActive = detailViewModel.IsActive,
                    
                });
            }

            await repo.AddAsync(sell);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var sell = await repo.All<Sell>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (sell != null)
            {
                sell.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }

        public async Task<SellViewModel> Get(Guid id)
        {
            SellViewModel model = new SellViewModel();
            var sell = await repo.All<Sell>()
                .Include(d => d.Details)
                .Include(d => d.Store)
                .Include(d => d.Contragent)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (sell != null)
            {
                model = new SellViewModel()
                {
                    Id = sell.Id,
                    ContragentId = sell.ContragentId,
                    Contragent = new ContragentViewModel()
                    {
                        Id = sell.Contragent.Id,
                        FirstName = sell.Contragent.FirstName,
                        LastName = sell.Contragent.LastName,
                        IsActive = sell.Contragent.IsActive,
                        VatNumber = sell.Contragent.VatNumber,
                        IsClient = sell.Contragent.IsClient,
                        IsSupplier = sell.Contragent.IsSupplier,
                    },
                    CreateDatetime = sell.CreateDatetime,
                    StoreId = sell.StoreId,
                    Store = new StoreViewModel()
                    {
                        Id = sell.Store.Id,
                        IsActive = sell.Store.IsActive,
                        Description = sell.Store.Description,
                        Name = sell.Store.Name,
                        AddressId = sell.Store.AddressId,
                    },
                    IsActive = sell.IsActive,
                };
                if (sell.Details != null)
                {
                    foreach (SellDetail detail in sell.Details)
                    {
                        SellDetailViewModel? detailViewmodel = model.Details.FirstOrDefault(d => d.Id == detail.Id);
                        if (detailViewmodel != null)
                        {
                            detailViewmodel.Id = detail.Id;
                            detailViewmodel.SellId = detail.SellId;
                            detailViewmodel.ArticleId = detail.ArticleId;
                            detailViewmodel.UnitId = detail.UnitId;
                            detailViewmodel.Qty = detail.Qty;
                            detailViewmodel.Price = detail.Price;
                            detailViewmodel.IsActive = detail.IsActive;
                        }
                        else
                        {
                            model.Details.Add(new SellDetailViewModel()
                            {
                                Id = detail.Id,
                                SellId = detail.SellId,
                                ArticleId = detail.ArticleId,
                                UnitId = detail.UnitId,
                                Qty = detail.Qty,
                                Price = detail.Price,
                                IsActive = detail.IsActive,
                            });
                        }
                    }
                }
            }
            return model;
        }

        public async Task<IEnumerable<SellViewModel>> GetAll()
        {
            return await repo.AllReadonly<Sell>()
                .Where(d => d.IsActive)
                .Include(d => d.Contragent)
                .Include(d => d.Store)
                .Select(d => new SellViewModel()
                {
                    Id = d.Id,
                    ContragentId = d.ContragentId,
                    Contragent = new ContragentViewModel()
                    {
                        Id = d.Contragent.Id,
                        FirstName = d.Contragent.FirstName,
                        LastName = d.Contragent.LastName,
                        VatNumber = d.Contragent.VatNumber,
                        IsSupplier = d.Contragent.IsSupplier,
                        IsClient = d.Contragent.IsClient,
                        IsActive = d.Contragent.IsActive,
                    },
                    StoreId = d.StoreId,
                    Store = new StoreViewModel()
                    {
                        Id = d.Store.Id,
                        IsActive = d.Store.IsActive,
                        Description = d.Store.Description,
                        Name = d.Store.Name,
                    },
                    CreateDatetime = d.CreateDatetime,
                    IsActive = d.IsActive,
                }).ToListAsync();
        }

        public async Task Update(SellViewModel viewModel)
        {
            var sell = await repo.GetByIdAsync<Sell>(viewModel.Id);
            if (sell != null)
            {
                sell.Id = viewModel.Id;
                sell.CreateDatetime = viewModel.CreateDatetime ?? DateTime.Now;
                sell.StoreId = viewModel.StoreId;
                sell.ContragentId = viewModel.ContragentId;
                sell.IsActive = viewModel.IsActive;
                foreach (SellDetailViewModel detailViewModel in viewModel.Details)
                {
                    if (detailViewModel.IsActive)
                    {
                        SellDetail? detail = sell.Details.FirstOrDefault(x => x.Id == detailViewModel.Id);
                        if (detail != null)
                        {
                            detail.ArticleId = detailViewModel.ArticleId;
                            detail.Price = detailViewModel.Price;
                            detail.Qty = detailViewModel.Qty;
                            detail.Sell = sell;
                            detail.SellId = sell.Id;
                            detail.UnitId = detailViewModel.UnitId;
                            detail.IsActive = sell.IsActive;
                        }
                        else
                        {
                            sell.Details.Add(new SellDetail()
                            {
                                Id = detailViewModel.Id,
                                ArticleId = detailViewModel.ArticleId,
                                Price = detailViewModel.Price,
                                Qty = detailViewModel.Qty,
                                Sell = sell,
                                SellId = sell.Id,
                                UnitId = detailViewModel.UnitId,
                                IsActive = detailViewModel.IsActive,
                            });
                        }
                    }
                    else
                    {
                        SellDetail? detail = sell.Details.FirstOrDefault(x => x.Id == detailViewModel.Id);
                        if (detail != null)
                        {
                            sell.Details.Remove(detail);
                        }
                    }
                }

                await repo.SaveChangesAsync();
            }
        }
    }
}
