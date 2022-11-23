using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;

namespace SBS.Controllers
{
    public class SellController : Controller
    {
        private readonly ISellService service;
        private readonly IContragentService contragentService;
        private readonly IStoreService storeService;
        private readonly IPartidesInStoresService partidesInStoresService;
        private readonly IUnitService unitService;
        private readonly IDeliveryService deliveryService;

        public SellController(
            ISellService service,
            IContragentService contragentService,
            IStoreService storeService,
            IPartidesInStoresService partidesInStoresService,
            IUnitService unitService
,
            IDeliveryService deliveryService)
        {
            this.service = service;
            this.contragentService = contragentService;
            this.storeService = storeService;
            this.partidesInStoresService = partidesInStoresService;
            this.unitService = unitService;
            this.deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var sells = await service.GetAll();
            ViewData["Title"] = "Sells";

            return View(sells);
        }

        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {
            var model = new SellViewModel();
            SellDetailViewModel det = new SellDetailViewModel();
            det.Sell = model;
            det.SellId = det.Id;
            model.Details.Add(det);

            ViewBag.ContragentsList = await GetContragents();
            ViewBag.StoresList = await GetStores();
            ViewBag.PartidesInStore = await GetPartidesInStore();
            ViewBag.UnitsList = await GetUnits();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SellViewModel viewModel)
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
        public async Task<ActionResult> Details(Guid id)
        {
            var sell = await service.Get(id);

            ViewBag.ContragentsList = await GetContragents();
            ViewBag.StoresList = await GetStores();
            ViewBag.PartidesInStore = await GetPartidesInStore();
            ViewBag.UnitsList = await GetUnits();

            if (sell != null)
            {
                return View(sell);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var sell = await service.Get(id);

            ViewBag.ContragentsList = await GetContragents();
            ViewBag.StoresList = await GetStores();
            ViewBag.PartidesInStore = await GetPartidesInStore();
            ViewBag.UnitsList = await GetUnits();

            if (sell != null)
            {
                return View(sell);
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(SellViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await service.Update(viewModel);

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
        public async Task<ActionResult> Delete(Guid id)
        {
            var delivery = await service.Get(id);
            ViewBag.ContragentsList = await GetContragents();
            ViewBag.StoresList = await GetStores();
            ViewBag.GetPartidesInStore = await GetPartidesInStore();
            ViewBag.UnitsList = await GetUnits();
            //TempData.Keep();
            if (delivery != null)
            {
                return View(delivery);
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(SellViewModel viewModel)
        {

            await service.Delete(viewModel.Id);

            try
            {
                TempData["SuccessMessage"] = "Sell " + viewModel.Id + " deleted successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

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

        [HttpGet]
        public async Task<JsonResult> GetUnitForArticle(Guid id)
        {
            var result = "";

            DeliveryDetailViewModel partide = await deliveryService.GetPartide(id);
            result = partide.Article.Unit.Name;

            return Json(result);
        }

        private async Task<IEnumerable<SelectListItem>> GetContragents()
        {
            var result = new List<SelectListItem>();

            IEnumerable<ContragentViewModel> contragentsList = await contragentService.GetAll();

            result = contragentsList
                .Where(x => x.IsClient)
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = String.Format("{0} {1}", x.FirstName, x.LastName),
                }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select Client" });
            return result;
        }

        private async Task<IEnumerable<SelectListItem>> GetStores()
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
