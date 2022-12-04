using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Articles in Stores
    /// </summary>
    public interface IArticlesInStockService
    {
        /// <summary>
        /// Get All Data for Articles in Sotores
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ArticlesInStockViewModel>> GetAll();
    }
}
