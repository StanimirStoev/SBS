using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using SBS.Tools;

namespace SBS.Core.Services
{
    /// <summary>
    /// Service for Articles
    /// </summary>
    public class ArticleService : IArticleService
    {
        private readonly ISbsRepository repo;
        /// <summary>
        /// Init service
        /// </summary>
        /// <param name="repo"></param>
        public ArticleService(ISbsRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// Add Article in repository
        /// </summary>
        /// <param name="articleViewModel"></param>
        /// <returns></returns>
        public async Task Add(ArticleViewModel articleViewModel)
        {
            Sanitizer.Sanitize(articleViewModel);
            var article = new Article()
            {
                Name = articleViewModel.Name,
                Model = articleViewModel.Model,
                DeliveryNumber = articleViewModel.DeliveryNumber,
                Description = articleViewModel.Description,
                Title = articleViewModel.Title,
                UnitId = articleViewModel.UnitId,
            };

            await repo.AddAsync(article);
            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// Delete Article from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            var product = await repo.All<Article>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Get list of all Articles
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ArticleViewModel>> GetAll()
        {
            return await repo.AllReadonly<Article>()
            .Where(p => p.IsActive)
            .Select(p => new ArticleViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                DeliveryNumber = p.DeliveryNumber,
                Description = p.Description,
                IsActive = p.IsActive,
                Model = p.Model,
                Title = p.Title,
            }).ToListAsync();
        }
        /// <summary>
        /// Gets Article from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ArticleViewModel> Get(Guid id)
        {
            ArticleViewModel model = new ArticleViewModel();
            var product = await repo.All<Article>()
                .Where(a => a.Id == id)
                .Include(a => a.Unit)
                .FirstOrDefaultAsync();

            if (product != null)
            {
                model = new ArticleViewModel()
                {
                    Id = product.Id,
                    Title = product.Title,
                    DeliveryNumber = product.DeliveryNumber,
                    IsActive = product.IsActive,
                    Description = product.Description,
                    Model = product.Model,
                    Name = product.Name,
                    UnitId = product.UnitId,
                    Unit = new UnitViewModel()
                    {
                        Id = product.Unit.Id,
                        Name = product.Unit.Name,
                        Description = product.Unit.Description ?? "",
                        IsActive = product.Unit.IsActive,
                    },
                };
            }
            return model;
        }
        /// <summary>
        /// Updates a Article
        /// </summary>
        /// <param name="articleViewModel"></param>
        /// <returns></returns>
        public async Task Update(ArticleViewModel articleViewModel)
        {
            Sanitizer.Sanitize(articleViewModel);
            var article = await repo.GetByIdAsync<Article>(articleViewModel.Id);
            if (article != null)
            {
                article.Name = articleViewModel.Name;
                article.Model = articleViewModel.Model;
                article.DeliveryNumber = articleViewModel.DeliveryNumber;
                article.Description = articleViewModel.Description;
                article.Title = articleViewModel.Title;
                article.IsActive = articleViewModel.IsActive;
                article.UnitId = articleViewModel.UnitId;

                await repo.SaveChangesAsync();
            }
        }
    }
}
