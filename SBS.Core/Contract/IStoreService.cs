using SBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Contract
{
    public interface IStoreService
    {
        Task<IEnumerable<StoreViewModel>> GetAll();

        Task Add(StoreViewModel storeViewModel);

        Task Delete(Guid id);

        Task<StoreViewModel> Get(Guid id);

        Task Update(StoreViewModel storeViewModel);
    }
}
