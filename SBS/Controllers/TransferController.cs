using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Contract;
using SBS.Core.Models;

namespace SBS.Controllers
{
    /// <summary>
    /// Controller for Transfers
    /// </summary>
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class TransferController : Controller
    {
        private readonly ITransferService service;
        private readonly IArticleService articleService;
        private readonly IStoreService storeService;
        private readonly IUnitService unitService;
        private readonly IPartidesInStoresService partidesInStoresService;
        private readonly IDeliveryService deliveryService;

        /// <summary>
        /// Init Controller
        /// </summary>
        /// <param name="service"></param>
        /// <param name="articleService"></param>
        /// <param name="storeService"></param>
        /// <param name="unitService"></param>
        /// <param name="partidesInStoresService"></param>
        /// <param name="deliveryService"></param>
        public TransferController(
            ITransferService service,
            IArticleService articleService,
            IStoreService storeService,
            IUnitService unitService,
            IPartidesInStoresService partidesInStoresService,
            IDeliveryService deliveryService)
        {
            this.service = service;
            this.articleService = articleService;
            this.storeService = storeService;
            this.unitService = unitService;
            this.partidesInStoresService = partidesInStoresService;
            this.deliveryService = deliveryService;
        }

        /// <summary>
        /// Prepare data for Transfers view 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var transfers = await service.GetAll();
            ViewData["Title"] = "Transfers";

            return View(transfers);
        }

        /// <summary>
        /// Prepare data for create new Transfer view 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {
            var model = new TransferViewModel();
            TransferDetailViewModel det = new TransferDetailViewModel();
            det.Transfer = model;
            det.TransferId = det.Id;
            model.Details.Add(det);

            ViewBag.FromStoresList = await GetFromStores();
            ViewBag.UnitsList = await GetUnits();

            return View(model);
        }
        /// <summary>
        /// Process Create Transfer view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
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

        /// <summary>
        /// Prepare data for details Transfer view 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var transfer = await service.Get(id);

            ViewBag.StoresList = await GetFromStores();
            ViewBag.UnitsList = await GetUnits();
            ViewBag.Partides = await GetPartidesInStore();

            if (transfer != null)
            {
                return View(transfer);
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Get list of possible destination stores
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get Articles quontity for store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetArticlesInStore(Guid id)
        {
            var result = new List<SelectListItem>();

            IEnumerable<PartidesInStoreViewModel> list = await partidesInStoresService.GetAll();

            list = list.Where(p => p.StoreId == id).ToList();

            result = list.Select(x => new SelectListItem()
            {
                Value = x.DeliveryDetailId.ToString(),
                Text = string.Format("{0} / {1:dd:MM:yyyy} - [{2}]",
                x.DeliveryDetail.Article.Name,
                x.DeliveryDetail.Delivery.CreateDatetime,
                x.Qty)
            }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select Item" });

            return Json(result);
        }

        /// <summary>
        /// Get Unit for article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetUnitForArticle(Guid id)
        {
            var result = "";

            DeliveryDetailViewModel partide = await deliveryService.GetPartide(id);
            result = partide.Article?.Unit?.Name;

            return Json(result);
        }

        /// <summary>
        /// Get All stores that can be used for sources (has 1 or more article in it)
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get all pertides in store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get list of all units
        /// </summary>
        /// <returns></returns>
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
