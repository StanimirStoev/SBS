using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Tools;

namespace SBS.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IUnitService unitService;

        public ArticleController(
            IArticleService articleService, 
            IUnitService unitService)
        {
            this.articleService = articleService;
            this.unitService = unitService;
        }

        // GET: ArticleController
        [HttpGet]
        public async Task<ActionResult> Index(string sortExpression = "")
        {
            SortHelper sortHelper = new SortHelper();

            var articles = await articleService.GetAll();

            ViewData["Title"] = "Articles";

            return View(articles);
        }

        // GET: ArticleController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ArticleViewModel();

            ViewBag.Units = GetUnits();

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

        private async Task<IEnumerable<SelectListItem>> GetUnits()
        {
            var result = new List<SelectListItem>();

            IEnumerable<UnitViewModel> countryList = await unitService.GetAll();

            result = countryList.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select Unit" });
            return result;
        }
    }
}
