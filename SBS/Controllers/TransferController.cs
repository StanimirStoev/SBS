using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Infrastructure.Data.Models;

namespace SBS.Controllers
{
    public class TransferController : Controller
    {
        private readonly ITransferService service;
        private readonly IArticleService articleService;
        private readonly IStoreService storeService;
        private readonly IUnitService unitService;
        private readonly IPartidesInStoresService partidesInStoresService;

        public TransferController(
            ITransferService service,
            IArticleService articleService,
            IStoreService storeService,
            IUnitService unitService,
            IPartidesInStoresService partidesInStoresService)
        {
            this.service = service;
            this.articleService = articleService;
            this.storeService = storeService;
            this.unitService = unitService;
            this.partidesInStoresService = partidesInStoresService;
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
            ViewBag.PartidesList = await GetPartidesInStore();
            ViewBag.UnitsList = await GetUnits();

            return View(model);
        }
        // POST: ContragentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TransferViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            viewModel.Details.RemoveAll(d => d.IsActive == false);

            await service.Add(viewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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

        private async Task<IEnumerable<SelectListItem>> GetPartidesInStore(Guid? id = null)
        {
            var result = new List<SelectListItem>();

            IEnumerable<PartidesInStoreViewModel> list = await partidesInStoresService.GetAll();
            if (id != null)
            {
                list = list.Where(p => p.StoreId == id).ToList();
            }

            result = list.Select(x => new SelectListItem()
            {
                Value = x.DeliveryDetailId.ToString(),
                Text = string.Format("{0} / {1:dd:MM:yyyy} - [{2}]", 
                    x.DeliveryDetail.Article.Name, 
                    x.DeliveryDetail.Delivery.CreateDatetime, 
                    x.Qty)
            }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select Item" });
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
