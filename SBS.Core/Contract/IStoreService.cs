using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Stores
    /// </summary>
    public interface IStoreService
    {
        /// <summary>
        /// Get list of all stores
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StoreViewModel>> GetAll();

        /// <summary>
        /// Get list of all stores that has 1 or more quantity in it
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StoreViewModel>> GetAllNotEmpty();

        /// <summary>
        /// Get list of all stores that has 1 or more quantity in it, but exclude store with given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<StoreViewModel>> GetAllExcluded(Guid id);

        /// <summary>
        /// Add store in repository
        /// </summary>
        /// <param name="storeViewModel"></param>
        /// <returns></returns>
        Task Add(StoreViewModel storeViewModel);

        /// <summary>
        /// Delete Store from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Gets store from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StoreViewModel> Get(Guid id);

        /// <summary>
        /// Updates an store
        /// </summary>
        /// <param name="storeViewModel"></param>
        /// <returns></returns>
        Task Update(StoreViewModel storeViewModel);
    }
}
