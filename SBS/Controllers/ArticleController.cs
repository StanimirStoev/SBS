using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Tools;

namespace SBS.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        // GET: ArticleController
        [HttpGet]
        public async Task<ActionResult> Index(string sortExpression = "")
        {
            SortHelper sortHelper = new SortHelper();
            sortHelper.AddColumn("Name");
            sortHelper.AddColumn("Model");
            sortHelper.AddColumn("Description");
            sortHelper.AddColumn("Title");
            sortHelper.AddColumn("DeliveryNumber");
            ViewData["sortModel"] = sortHelper;

            var articles = await articleService.GetAll();

            //sortHelper.ApplySort(sortExpression, ref articles);

            ViewData["Title"] = "Articles";

            return View(articles);
        }

        // GET: ArticleController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ArticleViewModel();
            return View(model);
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ArticleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await articleService.Add(viewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var article = await articleService.Get(id);

            if (article != null)
            {
                return View(article);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(ArticleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await articleService.Update(viewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await articleService.Delete(id);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
