using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Contragents
    /// </summary>
    public interface IContragentService
    {
        /// <summary>
        /// Get list of all contragents
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ContragentViewModel>> GetAll();

        /// <summary>
        /// Add contragent in repository
        /// </summary>
        /// <param name="contragentViewModel"></param>
        /// <returns></returns>
        Task Add(ContragentViewModel contragentViewModel);

        /// <summary>
        /// Delete contragent from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Gets country from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContragentViewModel> Get(Guid id);

        /// <summary>
        /// Updates a contragent
        /// </summary>
        /// <param name="contragentViewModel"></param>
        /// <returns></returns>
        Task Update(ContragentViewModel contragentViewModel);
    }
}
