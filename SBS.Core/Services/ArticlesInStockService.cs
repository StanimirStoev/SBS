using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Services
{
    public class ArticlesInStockService : IArticlesInStockService
    {
        private readonly ISbsRepository repo;

        public ArticlesInStockService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<ArticlesInStockViewModel>> GetAll()
        {
            List< ArticlesInStockViewModel> result = await repo.AllReadonly<DeliveryDetail>()
                .Where(d => d.Delivery.IsConfirmed == true)
                .Include(d => d.PartidesInStores)
                .Select(d => new ArticlesInStockViewModel()
                {
                    ArticleModel = d.Article.Model,
                    ArticleName = d.Article.Name,
                    StoreName = d.Delivery.Store.Name,
                    Quantity = d.Qty,
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
