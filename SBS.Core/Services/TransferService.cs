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
    public class TransferService : ITransferService
    {
        private readonly ISbsRepository repo;

        public TransferService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(TransferViewModel viewModel)
        {
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
                    TransferDetail? detail = transfer.Details.FirstOrDefault(x => x.Id == detailViewModel.Id);
                    if (detail != null)
                    {
                        detail.TransferId = detailViewModel.TransferId;
                        detail.DeliveryDetailId = detailViewModel.DeliveryDetailId;
                        detail.Qty = detailViewModel.Qty;
                        detail.IsActive = detailViewModel.IsActive;
                    }
                    else
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
                else
                {
                    TransferDetail? detail = transfer.Details.FirstOrDefault(x => x.Id == detailViewModel.Id);
                    if (detail != null)
                    {
                        transfer.Details.Remove(detail);
                    }
                }
            }

            //Do Transfer
            foreach (TransferDetail detail in transfer.Details)
            {
                PartidesInStore? fromPartInStore = await repo.All<PartidesInStore>()
                    .FirstOrDefaultAsync(d => d.DeliveryDetailId == detail.DeliveryDetailId  && d.StoreId == transfer.FromStoreId);
                PartidesInStore? toPartInStore = await repo.All<PartidesInStore>()
                    .FirstOrDefaultAsync(d => d.DeliveryDetailId == detail.DeliveryDetailId && d.StoreId == transfer.ToStoreId);
                if(toPartInStore == null)
                {
                    toPartInStore = new PartidesInStore()
                    {
                        DeliveryDetailId = detail.DeliveryDetailId,
                        StoreId = transfer.ToStoreId,
                        Qty = 0,
                    };
                    await repo.AddAsync<PartidesInStore>(toPartInStore);
                }
                fromPartInStore.Qty-= detail.Qty;
                toPartInStore.Qty += detail.Qty;
            }

            await repo.AddAsync(transfer);
            await repo.SaveChangesAsync();
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
