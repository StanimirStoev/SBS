using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Contract;
using SBS.Core.Models;

namespace SBS.Controllers
{
    /// <summary>
    /// Controller for Stores
    /// </summary>
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class StoreController : Controller
    {
        private readonly IStoreService service;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;

        /// <summary>
        /// Init controller
        /// </summary>
        /// <param name="service"></param>
        /// <param name="countryService"></param>
        /// <param name="cityService"></param>
        public StoreController(
            IStoreService service, 
            ICountryService countryService, 
            ICityService cityService)
        {
            this.service = service;
            this.countryService = countryService;
            this.cityService = cityService;
        }

        /// <summary>
        /// Prepare data for Stores view 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var stores = await service.GetAll();
            ViewData["Title"] = "Stores";

            return View(stores);
        }

        /// <summary>
        /// Prepare data for create new Store view 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {
            var model = new StoreViewModel();
            model.Address = new AddressViewModel();

            ViewBag.CountriesList = await GetCountries();
            ViewBag.CitiesList = await GetCities();

            return View(model);
        }

        /// <summary>
        /// Process Create Store view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(StoreViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

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
        /// Prepare edit view data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var store = await service.Get(id);

            ViewBag.CountriesList = await GetCountries();

            if (store != null)
            {
                return View(store);
            }

            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Process edit data from view
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> EditAsync(StoreViewModel viewModel)
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
        /// Process delete data from view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
            await service.Delete(id);

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
        /// Get all cities
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetCities(Guid id)
        {
            var result = new List<SelectListItem>();

            IEnumerable<CityViewModel> storesList = await cityService.GetForCountry(id);

            result = storesList.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            return Json(result);
        }

        /// <summary>
        /// Get all countries
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<SelectListItem>> GetCountries()
        {
            var result = new List<SelectListItem>();

            IEnumerable<CountryViewModel> countryList = await countryService.GetAll();

            result = countryList.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select Country" });
            return result;
        }

        /// <summary>
        /// Get Cities
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<SelectListItem>> GetCities()
        {
            var result = new List<SelectListItem>();

            IEnumerable<CityViewModel> countryList = await cityService.GetAll();

            result = countryList.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();

            result.Insert(0, new SelectListItem() { Value = "", Text = "Select City" });
            return result;
        }
    }
}
