using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;

namespace SBS.Controllers
{
    /// <summary>
    /// Controller for article in stores
    /// </summary>
    [Authorize(Roles ="Admin, Manager")]
    [AutoValidateAntiforgeryToken]
    public class ArticlesInStockController : Controller
    {
        private readonly IArticlesInStockService articleService;
        /// <summary>
        /// Init controller
        /// </summary>
        /// <param name="articleService"></param>
        public ArticlesInStockController(IArticlesInStockService articleService)
        {
            this.articleService = articleService;
        }

        /// <summary>
        /// Prepare data for article in stores view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> IndexAsync()
        {
            var articles = await articleService.GetAll();

            ViewData["Title"] = "Articles in stock";

            return View(articles);
        }
    }
}
