using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Partides in Stores
    /// </summary>
    public interface IPartidesInStoresService
    {
        /// <summary>
        /// Get list of all Partides in Stores
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PartidesInStoreViewModel>> GetAll();
    }
}
