using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;

namespace SBS.Controllers
{
    [Authorize(Roles ="Admin, Manager")]
    [AutoValidateAntiforgeryToken]
    public class ArticlesInStockController : Controller
    {
        private readonly IArticlesInStockService articleService;

        public ArticlesInStockController(IArticlesInStockService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var articles = await articleService.GetAll();

            ViewData["Title"] = "Articles in stock";

            return View(articles);
        }
    }
}
