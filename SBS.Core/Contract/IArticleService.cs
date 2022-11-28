using SBS.Core.Models;

namespace SBS.Core.Contract
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleViewModel>> GetAll();

        Task Add(ArticleViewModel articleViewModel);

        Task Delete(Guid id);

        Task<ArticleViewModel> Get(Guid id);

        Task Update(ArticleViewModel articleViewModel);
    }
}
