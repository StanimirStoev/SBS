using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using SBS.Tools;

namespace SBS.Core.Services
{
    public class TransferService : ITransferService
    {
        private readonly ISbsRepository repo;

        public TransferService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(TransferViewModel viewModel)
        {
            Sanitizer.Sanitize(viewModel);
            var transfer = new Transfer()
            {
                Id = viewModel.Id,
                CreateDatetime = viewModel.CreateDatetime,
                FromStoreId = viewModel.FromStoreId,
                ToStoreId = viewModel.ToStoreId,
                IsActive = viewModel.IsActive,
            };
            foreach (TransferDetailViewModel detailViewModel in viewModel.Details)
            {
                if (detailViewModel.IsActive)
                {
                    transfer.Details.Add(new TransferDetail()
                    {
                        Id = detailViewModel.Id,
                        TransferId = transfer.Id,
                        DeliveryDetailId = detailViewModel.DeliveryDetailId,
                        Qty = detailViewModel.Qty,
                        IsActive = detailViewModel.IsActive,
                    });
                }
            }

            //Do Transfer
            foreach (TransferDetail detail in transfer.Details)
            {
                PartidesInStore? fromPartInStore = await repo.All<PartidesInStore>()
                    .FirstOrDefaultAsync(d => d.DeliveryDetailId == detail.DeliveryDetailId && d.StoreId == transfer.FromStoreId);
                PartidesInStore? toPartInStore = await repo.All<PartidesInStore>()
                    .FirstOrDefaultAsync(d => d.DeliveryDetailId == detail.DeliveryDetailId && d.StoreId == transfer.ToStoreId);
                if (toPartInStore == null)
                {
                    toPartInStore = new PartidesInStore()
                    {
                        DeliveryDetailId = detail.DeliveryDetailId,
                        StoreId = transfer.ToStoreId,
                        Qty = 0,
                    };
                    await repo.AddAsync<PartidesInStore>(toPartInStore);
                }
                fromPartInStore.Qty -= detail.Qty;
                toPartInStore.Qty += detail.Qty;
            }

            await repo.AddAsync(transfer);
            await repo.SaveChangesAsync();
        }

        public async Task<TransferViewModel> Get(Guid id)
        {
            TransferViewModel model = new TransferViewModel();
            var transfer = await repo.GetByIdAsync<Transfer>(id);

            Store storeFrom = await repo.GetByIdAsync<Store>(transfer.FromStoreId);
            Store storeTo = await repo.GetByIdAsync<Store>(transfer.ToStoreId);

            if (transfer != null)
            {
                model = new TransferViewModel()
                {
                    Id = transfer.Id,
                    CreateDatetime = transfer.CreateDatetime,
                    FromStoreId = transfer.FromStoreId,
                    FromStore = new StoreViewModel
                    {
                        Id = storeFrom.Id,
                        AddressId = storeFrom.AddressId,
                        IsActive = storeFrom.IsActive,
                        Name = storeFrom.Name,
                        Description = storeFrom.Description,
                    },
                    ToStoreId = transfer.ToStoreId,
                    ToStore = new StoreViewModel
                    {
                        Id = storeTo.Id,
                        AddressId = storeTo.AddressId,
                        IsActive = storeTo.IsActive,
                        Name = storeTo.Name,
                        Description = storeTo.Description,
                    },
                    IsActive = transfer.IsActive,
                };
                model.Details.AddRange(await repo.All<TransferDetail>()
                    .Include(d => d.DeliveryDetail)
                    .Where(d => d.TransferId == transfer.Id)
                    .Select(d => new TransferDetailViewModel()
                    {
                        Id = d.Id,
                        TransferId = transfer.Id,
                        DeliveryDetailId = d.DeliveryDetailId,
                        DeliveryDetail = new DeliveryDetailViewModel()
                        {
                            Id = d.DeliveryDetail.Id,
                            ArticleId = d.DeliveryDetail.ArticleId,
                            DeliveryId = d.DeliveryDetail.DeliveryId,
                            IsActive = d.DeliveryDetail.IsActive,
                            Price = d.DeliveryDetail.Price,
                            Qty = d.DeliveryDetail.Qty,
                            UnitId = d.DeliveryDetail.UnitId,
                        },
                        Qty = d.Qty,
                        IsActive = d.IsActive,
                    }).ToListAsync());
            }
            return model;
        }

        public async Task<IEnumerable<TransferViewModel>> GetAll()
        {
            var result = await repo.AllReadonly<Transfer>()
                .Where(t => t.IsActive)
                .Include(t => t.FromStore)
                .Include(t => t.ToStore)
                .Select(t => new TransferViewModel()
                {
                    Id = t.Id,
                    FromStoreId = t.FromStoreId,
                    FromStore = new StoreViewModel()
                    {
                        Id = t.FromStore.Id,
                        IsActive = t.FromStore.IsActive,
                        Description = t.FromStore.Description,
                        Name = t.FromStore.Name,
                    },
                    ToStoreId = t.ToStoreId,
                    ToStore = new StoreViewModel()
                    {
                        Id = t.ToStore.Id,
                        IsActive = t.ToStore.IsActive,
                        Description = t.ToStore.Description,
                        Name = t.ToStore.Name,
                    },
                    CreateDatetime = t.CreateDatetime,

                    IsActive = t.IsActive,
                }).ToListAsync();

            return result;
        }
    }
}
