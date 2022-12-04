using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Tools;

namespace SBS.Controllers
{
    /// <summary>
    /// Controller for Deliveries
    /// </summary>
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class ContragentController : Controller
    {
        private readonly IContragentService service;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;

        /// <summary>
        /// Init conreoller
        /// </summary>
        /// <param name="service"></param>
        /// <param name="countryService"></param>
        /// <param name="cityService"></param>
        public ContragentController(
            IContragentService service, 
            ICountryService countryService,
            ICityService cityService)
        {
            this.service = service;
            this.countryService = countryService;
            this.cityService = cityService;
        }

        /// <summary>
        /// Prepare data for contragents view
        /// </summary>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index(string sortExpression = "")
        {
            SortHelper sortHelper = new SortHelper();
            sortHelper.AddColumn("FirstName");
            sortHelper.AddColumn("LastName");
            sortHelper.AddColumn("VatNumber");
            sortHelper.AddColumn("IsClient");
            sortHelper.AddColumn("IsSupplier");
            ViewData["sortModel"] = sortHelper;

            var contragents = await service.GetAll();

            //sortHelper.ApplySort(sortExpression, ref contragents);

            ViewData["Title"] = "Contragents";

            return View(contragents);
        }

        /// <summary>
        /// Prepare data for create new contragent view 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var model = new ContragentViewModel();
            model.Addresses.Add(new AddressViewModel());

            ViewBag.CountriesList = await GetCountries();
            return View(model);
        }
        /// <summary>
        /// Process Create new contragent view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(ContragentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            viewModel.Addresses.RemoveAll(a => a.IsActive == false);

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
        /// Prepare data for edit view 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var contragent = await service.Get(id);

            ViewBag.CountriesList = await GetCountries();

            if (contragent != null)
            {
                return View(contragent);
            }

            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Process Edit view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> EditAsync(ContragentViewModel viewModel)
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
        /// Process delete view data
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
        /// Get cities
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
        /// Get countries as SelectListItems
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
        /// Get cities as SelectListItems
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
