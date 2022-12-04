using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Contract;
using SBS.Core.Models;

namespace SBS.Controllers
{
    /// <summary>
    /// Controller for Deliveries
    /// </summary>
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService service;
        private readonly IContragentService contragentService;
        private readonly IStoreService storeService;
        private readonly IArticleService articleService;
        private readonly IUnitService unitService;

        /// <summary>
        /// Init Controller
        /// </summary>
        /// <param name="service"></param>
        /// <param name="contragentService"></param>
        /// <param name="storeService"></param>
        /// <param name="articleService"></param>
        /// <param name="unitService"></param>
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

        /// <summary>
        /// Prepare data for Deliveries view 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var deliveries = await service.GetAll();
            ViewData["Title"] = "Deliveries";

            return View(deliveries);
        }

        /// <summary>
        /// Prepare data for create new Delivery view 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Process Create new Delivery view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
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

        /// <summary>
        /// Prepare data for details view 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Prepare data for edit view 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Process Edit view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
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

        /// <summary>
        /// Prepare data for delete view 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Process delete view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
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

        /// <summary>
        /// Process conferming view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ConfirmAsync(DeliveryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await service.Confirm(viewModel);

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
        /// Get contragents as SelectListItems
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get stores as SelectListItems
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get Articles as SelectListItems
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get units as SelectListItems
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
