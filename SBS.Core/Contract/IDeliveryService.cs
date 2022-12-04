using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Deliveries
    /// </summary>
    public interface IDeliveryService
    {
        /// <summary>
        /// Get list of all Deliveries
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DeliveryViewModel>> GetAll();

        /// <summary>
        /// Add Delivery in repository
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        Task Add(DeliveryViewModel viewModel);

        /// <summary>
        /// Delete Delivery from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Gets Delivery from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DeliveryViewModel> Get(Guid id);

        /// <summary>
        /// Get a partide by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DeliveryDetailViewModel> GetPartide(Guid id);

        /// <summary>
        /// Update Delivery in repository
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        Task Update(DeliveryViewModel viewModel);

        /// <summary>
        /// Do comfirmation for a Delivery
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        Task Confirm(DeliveryViewModel viewModel);
    }
}
