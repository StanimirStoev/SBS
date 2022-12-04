using SBS.Core.Models;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Articles
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// Get list of all Articles
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ArticleViewModel>> GetAll();
        /// <summary>
        /// Add Article in repository
        /// </summary>
        /// <param name="articleViewModel"></param>
        /// <returns></returns>
        Task Add(ArticleViewModel articleViewModel);
        /// <summary>
        /// Delete Article from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
        /// <summary>
        /// Gets Article from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ArticleViewModel> Get(Guid id);
        /// <summary>
        /// Updates a Article
        /// </summary>
        /// <param name="articleViewModel"></param>
        /// <returns></returns>
        Task Update(ArticleViewModel articleViewModel);
    }
}
