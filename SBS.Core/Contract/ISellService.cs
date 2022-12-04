using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Sells
    /// </summary>
    public interface ISellService
    {
        /// <summary>
        /// Get list of all Sells
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SellViewModel>> GetAll();

        /// <summary>
        /// Add Sell in repository
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        Task Add(SellViewModel viewModel);

        /// <summary>
        /// Delete Sell from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Gets sell from Transfer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SellViewModel> Get(Guid id);

        /// <summary>
        /// Update Sell in repository
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        Task Update(SellViewModel viewModel);
    }
}
