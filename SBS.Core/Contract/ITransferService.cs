using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Units
    /// </summary>
    public interface ITransferService
    {
        /// <summary>
        /// Get list of all Transfers
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TransferViewModel>> GetAll();

        /// <summary>
        /// Gets unit from Transfer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TransferViewModel> Get(Guid id);

        /// <summary>
        /// Add Transfer in repository
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        Task Add(TransferViewModel viewModel);
    }
}
