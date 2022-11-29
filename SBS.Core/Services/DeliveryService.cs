using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using SBS.Tools;

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
            Sanitizer.Sanitize(viewModel);
            var delivery = new Delivery()
            {
                Id = viewModel.Id,
                CreateDatetime = viewModel.CreateDatetime ?? DateTime.Now,
                ContragentId = viewModel.ContragentId,
                StoreId = viewModel.StoreId,
                IsConfirmed = false,
                IsActive = viewModel.IsActive,
            };
            foreach (DeliveryDetailViewModel detailViewModel in viewModel.Details)
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

            await repo.AddAsync(delivery);
            await repo.SaveChangesAsync();
        }

        public async Task Confirm(DeliveryViewModel viewModel)
        {
            //var delivery = await repo.GetByIdAsync<Delivery>(viewModel.Id);
            var delivery = await repo.All<Delivery>()
                .Include(d => d.Details)
                .FirstOrDefaultAsync(p => p.Id == viewModel.Id);

            if (delivery != null)
            {
                foreach (var item in delivery.Details)
                {
                    await repo.AddAsync<PartidesInStore>(new PartidesInStore()
                    {
                        DeliveryDetailId = item.Id,
                        StoreId = viewModel.StoreId,
                        Qty = item.Qty,
                    });
                }

                delivery.IsConfirmed = true;

                await repo.SaveChangesAsync();
            }
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
                    IsConfirmed = delivery.IsConfirmed,
                    IsActive = delivery.IsActive,
                };
                if (delivery.Details != null)
                {
                    foreach (DeliveryDetail detail in delivery.Details)
                    {
                        DeliveryDetailViewModel? detailViewmodel = model.Details.FirstOrDefault(d => d.Id == detail.Id);
                        if (detailViewmodel != null)
                        {
                            detailViewmodel.Id = detail.Id;
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

        public async Task<DeliveryDetailViewModel> GetPartide(Guid id)
        {
            DeliveryDetailViewModel model = new DeliveryDetailViewModel();
            var det = await repo.All<DeliveryDetail>()
                .Include(d => d.Article)
                .Include(d => d.Article.Unit)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (det != null)
            {
                model = new DeliveryDetailViewModel()
                {
                    Id = det.Id,
                    ArticleId = det.ArticleId,
                    Article = new ArticleViewModel()
                    {
                        Id = det.Article.Id,
                        DeliveryNumber = det.Article.DeliveryNumber,
                        Name = det.Article.Name,
                        Description = det.Article.Description,
                        Title = det.Article.Title,
                        Model = det.Article.Model,
                        UnitId = det.Article.UnitId,
                        Unit = new UnitViewModel()
                        {
                            Id = det.Article.Unit.Id,
                            Name = det.Article.Unit.Name,
                            Description = det.Article.Unit.Description ?? "",
                            IsActive = det.Article.Unit.IsActive,
                        },
                        IsActive = det.Article.IsActive,
                    },
                    IsActive = det.IsActive,
                };
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
                    IsConfirmed = d.IsConfirmed,
                    IsActive = d.IsActive,
                }).ToListAsync();
        }

        public async Task Update(DeliveryViewModel viewModel)
        {
            Sanitizer.Sanitize(viewModel);
            var delivery = await repo.GetByIdAsync<Delivery>(viewModel.Id);
            if (delivery != null)
            {
                delivery.Id = viewModel.Id;
                delivery.CreateDatetime = viewModel.CreateDatetime ?? DateTime.Now;
                delivery.StoreId = viewModel.StoreId;
                delivery.ContragentId = viewModel.ContragentId;
                delivery.IsActive = viewModel.IsActive;
                delivery.IsConfirmed = viewModel.IsConfirmed;
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
                            detail.Delivery = delivery;
                            detail.DeliveryId = delivery.Id;
                            detail.UnitId = detailViewModel.UnitId;
                            detail.IsActive = delivery.IsActive;
                        }
                        else
                        {
                            delivery.Details.Add(new DeliveryDetail()
                            {
                                Id = detailViewModel.Id,
                                ArticleId = detailViewModel.ArticleId,
                                Price = detailViewModel.Price,
                                Qty = detailViewModel.Qty,
                                Delivery = delivery,
                                DeliveryId = delivery.Id,
                                UnitId = detailViewModel.UnitId,
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
