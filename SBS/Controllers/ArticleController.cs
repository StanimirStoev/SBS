using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Tools;

namespace SBS.Controllers
{
    /// <summary>
    /// Controller for Articles
    /// </summary>
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IUnitService unitService;
        /// <summary>
        /// Init controller
        /// </summary>
        /// <param name="articleService"></param>
        /// <param name="unitService"></param>
        public ArticleController(
            IArticleService articleService, 
            IUnitService unitService)
        {
            this.articleService = articleService;
            this.unitService = unitService;
        }

        /// <summary>
        /// Prepare data for articles view
        /// </summary>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index(string sortExpression = "")
        {
            SortHelper sortHelper = new SortHelper();

            var articles = await articleService.GetAll();

            ViewData["Title"] = "Articles";

            return View(articles);
        }

        /// <summary>
        /// Prepare data for create new article view 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {
            var model = new ArticleViewModel();

            ViewBag.Units = await GetUnits();

            return View(model);
        }
        /// <summary>
        /// Process Create new city view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
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

        /// <summary>
        /// Prepare data for edit view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var article = await articleService.Get(id);

            ViewBag.Units = await GetUnits();

            if (article != null)
            {
                return View(article);
            }

            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Process Edit view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
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

        /// <summary>
        /// Process delete view data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
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

        /// <summary>
        /// Get Units as SelectListItems
        /// </summary>
        /// <returns></returns>
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
