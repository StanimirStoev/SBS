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
    public class DeliveryService : IDeliveryService
    {
        private readonly ISbsRepository repo;

        public DeliveryService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(DeliveryViewModel viewModel)
        {
            var delivery = new Delivery()
            {
                Id = viewModel.Id,
                CreateDatetime = viewModel.CreateDatetime ?? DateTime.Now,
                ContragentId = viewModel.ContragentId,
                StoreId = viewModel.StoreId,
                IsActive = viewModel.IsActive,
            };
            foreach(DeliveryDetailViewModel detailViewModel in viewModel.Details)
            {
                if(detailViewModel.IsActive)
                {
                    DeliveryDetail? detail = delivery.Details.FirstOrDefault(x => x.Id == detailViewModel.Id);
                    if(detail != null)
                    {
                        detail.ArticleId = detailViewModel.ArticleId;
                        detail.UnitId = detailViewModel.UnitId;
                        detail.Price = detailViewModel.Price;
                        detail.Qty = detailViewModel.Qty;
                        detail.Delivery = delivery;
                        detail.DeliveryId = detailViewModel.DeliveryId;
                    }
                    else
                    {
                        delivery.Details.Add(new DeliveryDetail()
                        {
                            Id = detailViewModel.Id,
                            ArticleId = detailViewModel.ArticleId,
                            UnitId = detailViewModel.UnitId,
                            Price = detailViewModel.Price,
                            Qty = detailViewModel.Qty,
                            Delivery = delivery,
                            IsActive = detailViewModel.IsActive,
                        });
                    }
                }
                else
                {
                    DeliveryDetail? detail = delivery.Details.FirstOrDefault(x => x.Id == detailViewModel.Id);
                    if(detail != null)
                    {
                        delivery.Details.Remove(detail);
                    }
                }
            }

            await repo.AddAsync(delivery);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var delivery = await repo.All<Delivery>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (delivery != null)
            {
                delivery.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }

        public async Task<DeliveryViewModel> Get(Guid id)
        {
            DeliveryViewModel model = new DeliveryViewModel();
            var delivery = await repo.All<Delivery>()
                .Include(d => d.Details)
                .Include(d => d.Store)
                .Include(d => d.Contragent)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (delivery != null)
            {
                model = new DeliveryViewModel()
                {
                    Id = delivery.Id,
                    ContragentId = delivery.ContragentId,
                    Contragent = new ContragentViewModel()
                    {
                        Id = delivery.Contragent.Id,
                        FirstName = delivery.Contragent.FirstName,
                        LastName = delivery.Contragent.LastName,
                        IsActive = delivery.Contragent.IsActive,
                        VatNumber = delivery.Contragent.VatNumber,
                        IsClient = delivery.Contragent.IsClient,
                        IsSupplier = delivery.Contragent.IsSupplier,
                    },
                    CreateDatetime = delivery.CreateDatetime,
                    StoreId = delivery.StoreId,
                    Store = new StoreViewModel()
                    {
                        Id = delivery.Store.Id,
                        IsActive = delivery.Store.IsActive,
                        Description = delivery.Store.Description,
                        Name = delivery.Store.Name,
                        AddressId = delivery.Store.AddressId,
                    },
                    IsActive = delivery.IsActive,
                };
                if (delivery.Details != null)
                {
                    foreach (DeliveryDetail detail in delivery.Details)
                    {
                        DeliveryDetailViewModel? detailViewmodel = model.Details.FirstOrDefault(d => d.Id == detail.Id);
                        if(detailViewmodel != null)
                        {
                            detailViewmodel.DeliveryId = detail.DeliveryId;
                            detailViewmodel.ArticleId = detail.ArticleId;
                            detailViewmodel.UnitId = detail.UnitId;
                            detailViewmodel.Qty = detail.Qty;
                            detailViewmodel.Price = detail.Price;
                            detailViewmodel.IsActive = detail.IsActive;
                        }
                        else
                        {
                            model.Details.Add(new DeliveryDetailViewModel()
                            {
                                Id = detail.Id,
                                DeliveryId = detail.DeliveryId,
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

        public async Task<IEnumerable<DeliveryViewModel>> GetAll()
        {
            return await repo.AllReadonly<Delivery>()
                .Where(d => d.IsActive)
                .Include(d => d.Contragent)
                .Include(d => d.Store)
                .Select(d => new DeliveryViewModel()
                {
                    Id = d.Id,
                    ContragentId = d.ContragentId,
                    Contragent   = new ContragentViewModel()
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

        public async Task Update(DeliveryViewModel viewModel)
        {
            var delivery = await repo.GetByIdAsync<Delivery>(viewModel.Id);
            if (delivery != null)
            {
                delivery.Id = viewModel.Id;
                delivery.CreateDatetime = viewModel.CreateDatetime ?? DateTime.Now;
                delivery.StoreId = viewModel.StoreId;
                delivery.ContragentId = viewModel.ContragentId;
                delivery.IsActive = viewModel.IsActive;
                foreach (DeliveryDetailViewModel detailViewModel in viewModel.Details)
                {
                    if (detailViewModel.IsActive)
                    {
                        DeliveryDetail? detail = delivery.Details.FirstOrDefault(x => x.Id == detailViewModel.Id);
                        if (detail != null)
                        {
                            detail.ArticleId = detailViewModel.ArticleId;
                            detail.Price = detailViewModel.Price;
                            detail.Qty = detailViewModel.Qty;
                            detail.DeliveryId = detailViewModel.DeliveryId;
                        }
                        else
                        {
                            delivery.Details.Add(new DeliveryDetail()
                            {
                                Id = detailViewModel.Id,
                                ArticleId = detailViewModel.ArticleId,
                                Price = detailViewModel.Price,
                                Qty = detailViewModel.Qty,
                                DeliveryId = detailViewModel.DeliveryId,
                                IsActive = detailViewModel.IsActive,
                            });
                        }
                    }
                    else
                    {
                        DeliveryDetail? detail = delivery.Details.FirstOrDefault(x => x.Id == detailViewModel.Id);
                        if (detail != null)
                        {
                            delivery.Details.Remove(detail);
                        }
                    }
                }

                await repo.SaveChangesAsync();
            }
        }
    }
}
