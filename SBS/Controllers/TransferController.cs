using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;

namespace SBS.Controllers
{
    public class TransferController : Controller
    {
        private readonly ITransferService service;
        private readonly IArticleService articleService;
        private readonly IStoreService storeService;
        private readonly IUnitService unitService;

        public TransferController(
            ITransferService service,
            IArticleService articleService,
            IStoreService storeService,
            IUnitService unitService)
        {
            this.service = service;
            this.articleService = articleService;
            this.storeService = storeService;
            this.unitService = unitService;
        }

        // GET: ContragentController
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var transfers = await service.GetAll();
            ViewData["Title"] = "Transfers";

            return View(transfers);
        }

        // GET: ContragentController/Create
        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {
            var model = new TransferViewModel();
            TransferDetailViewModel det = new TransferDetailViewModel();
            det.Transfer = model;
            det.TransferId = det.Id;
            model.Details.Add(det);

            ViewBag.FromStoresList = await GetFromStores();
            ViewBag.ArticlesList = await GetArticles();
            ViewBag.UnitsList = await GetUnits();

            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetToStores(Guid id)
        {
            var result = new List<SelectListItem>();

            IEnumerable<StoreViewModel> storesList = await storeService.GetAllExcluded(id);

            result = storesList.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            return Json(result);
        }

        private async Task<IEnumerable<SelectListItem>> GetFromStores()
        {
            var result = new List<SelectListItem>();

            IEnumerable<StoreViewModel> storesList = await storeService.GetAllNotEmpty();

            result = storesList.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select Store" });
            return result;
        }
        private async Task<IEnumerable<SelectListItem>> GetArticles()
        {
            var result = new List<SelectListItem>();

            IEnumerable<ArticleViewModel> list = await articleService.GetAll();

            result = list.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select Article" });
            return result;
        }
        private async Task<IEnumerable<SelectListItem>> GetUnits()
        {
            var result = new List<SelectListItem>();

            IEnumerable<UnitViewModel> list = await unitService.GetAll();

            result = list.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select Unit" });
            return result;
        }
    }
}
