using SBS.Core.Models;

namespace SBS.Core.Contract
{
    public interface IArticlesInStockService
    {
        Task<IEnumerable<ArticlesInStockViewModel>> GetAll();
    }
}
