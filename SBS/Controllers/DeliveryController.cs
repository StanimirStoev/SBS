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

        public DeliveryController(
            IDeliveryService service,
            IContragentService contragentService,
            IStoreService storeService)
        {
            this.service = service;
            this.contragentService = contragentService;
            this.storeService = storeService;
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

            ViewBag.ContragentsList = await GetContragents();
            ViewBag.StoresList = await GetStores();

            return View(model);
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
    }
}
