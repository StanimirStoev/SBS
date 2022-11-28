using SBS.Core.Models;

namespace SBS.Core.Contract
{
    public interface IStoreService
    {
        Task<IEnumerable<StoreViewModel>> GetAll();

        Task<IEnumerable<StoreViewModel>> GetAllNotEmpty();

        Task<IEnumerable<StoreViewModel>> GetAllExcluded(Guid id);

        Task Add(StoreViewModel storeViewModel);

        Task Delete(Guid id);

        Task<StoreViewModel> Get(Guid id);

        Task Update(StoreViewModel storeViewModel);
    }
}
