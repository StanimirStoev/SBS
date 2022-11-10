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

        public async Task<IEnumerable<TransferViewModel>> GetAll()
        {
            var result = await repo.AllReadonly<Transfer>()
                .Where(t => t.IsActive)
                .Include(t => t.FromStore)
                .Include(t => t.ToStore)
                .Select(t => new TransferViewModel()
                {
                    Id = t.Id,
                    FromStoreId= t.FromStoreId,
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
