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
            var delivery = await repo.GetByIdAsync<Delivery>(id);

            if (delivery != null)
            {
                model = new DeliveryViewModel()
                {
                    Id = delivery.Id,
                    ContragentId = delivery.ContragentId,
                    CreateDatetime = delivery.CreateDatetime,
                    StoreId = delivery.StoreId,
                    IsActive = delivery.IsActive,
                };
                if (delivery.Details != null)
                {
                    foreach (DeliveryDetail detail in delivery.Details)
                    {
                        DeliveryDetailViewModel? detailViewmodel = model.Details.FirstOrDefault(d => d.Id == detail.Id);
                        if(detailViewmodel != null)
                        {
                            detailViewmodel.IsActive = detail.IsActive;
                            detailViewmodel.ArticleId = detail.ArticleId;
                            detailViewmodel.Price = detail.Price;
                            detailViewmodel.Qty = detail.Qty;
                            detailViewmodel.DeliveryId = detail.DeliveryId;
                        }
                        else
                        {
                            model.Details.Add(new DeliveryDetailViewModel()
                            {
                                DeliveryId = detail.DeliveryId,
                                Qty = detail.Qty,
                                ArticleId = detail.ArticleId,
                                IsActive = detail.IsActive,
                                Id = detail.Id,
                                Price = detail.Price,
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
                .Select(d => new DeliveryViewModel()
                {
                    Id = d.Id,
                    ContragentId = d.ContragentId,
                    StoreId = d.StoreId,
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
