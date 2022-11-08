using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;

namespace SBS.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService service;
        private readonly IContragentService contragentService;
        private readonly IStoreService storeService;
        private readonly IArticleService articleService;
        private readonly IUnitService unitService;

        public DeliveryController(
            IDeliveryService service,
            IContragentService contragentService,
            IStoreService storeService,
            IArticleService articleService,
            IUnitService unitService)
        {
            this.service = service;
            this.contragentService = contragentService;
            this.storeService = storeService;
            this.articleService = articleService;
            this.unitService = unitService;
        }

        // GET: ContragentController
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var deliveries = await service.GetAll();
            ViewData["Title"] = "Stores";

            return View(deliveries);
        }

        // GET: ContragentController/Create
        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {
            var model = new DeliveryViewModel();
            DeliveryDetailViewModel det = new DeliveryDetailViewModel();
            det.Delivery = model;
            det.DeliveryId = det.Id;
            model.Details.Add(det);

            ViewBag.ContragentsList = await GetContragents();
            ViewBag.StoresList = await GetStores();
            ViewBag.ArticlesList = await GetArticles();
            ViewBag.UnitsList = await GetUnits();

            return View(model);
        }
        // POST: ContragentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DeliveryViewModel viewModel)
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

        // GET: ContragentController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var delivery = await service.Get(id);

            ViewBag.ContragentsList = await GetContragents();
            ViewBag.StoresList = await GetStores();
            ViewBag.ArticlesList = await GetArticles();
            ViewBag.UnitsList = await GetUnits();

            if (delivery != null)
            {
                return View(delivery);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ContragentController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var delivery = await service.Get(id);

            ViewBag.ContragentsList = await GetContragents();
            ViewBag.StoresList = await GetStores();
            ViewBag.ArticlesList = await GetArticles();
            ViewBag.UnitsList = await GetUnits();

            if (delivery != null)
            {
                return View(delivery);
            }

            return RedirectToAction(nameof(Index));
        }
        // POST: ContragentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(DeliveryViewModel viewModel)
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

        // GET: ContragentController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var delivery = await service.Get(id);
            ViewBag.ContragentsList = await GetContragents();
            ViewBag.StoresList = await GetStores();
            ViewBag.ArticlesList = await GetArticles();
            ViewBag.UnitsList = await GetUnits();
            //TempData.Keep();
            if (delivery != null)
            {
                return View(delivery);
            }

            return RedirectToAction(nameof(Index));
        }
        // POST: ContragentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DeliveryViewModel viewModel)
        {

            await service.Delete(viewModel.Id);

            try
            {
                TempData["SuccessMessage"] = "Delivery " + viewModel.Id + " deleted successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        private async Task<IEnumerable<SelectListItem>> GetContragents()
        {
            var result = new List<SelectListItem>();

            IEnumerable<ContragentViewModel> contragentsList = await contragentService.GetAll();

            result = contragentsList
                .Where(x => x.IsSupplier)
                .Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = String.Format("{0} {1}", x.FirstName, x.LastName),
            }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select Supplier" });
            return result;
        }

        private async Task<IEnumerable<SelectListItem>> GetStores()
        {
            var result = new List<SelectListItem>();

            IEnumerable<StoreViewModel> storesList = await storeService.GetAll();

            result = storesList.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text =  x.Name,
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
