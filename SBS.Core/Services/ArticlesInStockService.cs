using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;

namespace SBS.Core.Services
{
    /// <summary>
    /// Service for Articles in Stores
    /// </summary>
    public class ArticlesInStockService : IArticlesInStockService
    {
        private readonly ISbsRepository repo;
        /// <summary>
        /// Init Service
        /// </summary>
        /// <param name="repo"></param>
        public ArticlesInStockService(ISbsRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// Get All Data for Articles in Sotores
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ArticlesInStockViewModel>> GetAll()
        {
            List< ArticlesInStockViewModel> result = await repo.AllReadonly<PartidesInStore>()
                .Include(p => p.DeliveryDetail)
                .Include(p => p.DeliveryDetail.Article)
                .Include(p => p.Store)
                .Select(p => new ArticlesInStockViewModel()
                {
                    ArticleModel = p.DeliveryDetail.Article.Model,
                    ArticleName = p.DeliveryDetail.Article.Name,
                    StoreName = p.Store.Name,
                    Quantity = p.Qty,
                })
                .ToListAsync();

            result = result
                .GroupBy(x => (x.ArticleModel, x.StoreName))
                .Select(x => new ArticlesInStockViewModel()
                {
                    ArticleModel = x.First().ArticleModel,
                    ArticleName = x.First().ArticleName,
                    StoreName =x.First().StoreName,
                    Quantity = x.Sum(c => c.Quantity),
                })
                .OrderBy(x => x.ArticleModel)
                .ThenBy(x => x.StoreName)
                .ToList();

            return result;
        }
    }
}
