using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;
using SBS.Core.Models;

namespace SBS.Controllers
{
    /// <summary>
    /// Controller for Cities
    /// </summary>
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class CityController : Controller
    {
        private readonly ICityService cityService;
        /// <summary>
        /// Init Controller
        /// </summary>
        /// <param name="cityService"></param>
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        /// <summary>
        /// Prepare data for cities view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var cities = await cityService.GetAll();
            ViewData["Title"] = "Cities";

            return View(cities);
        }

        /// <summary>
        /// Prepare data for create new city view 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var model = new CityViewModelCreate();
            model.Countries = (List<CountryViewModel>)await cityService.GetAllCountries();
            return View(model);
        }
        /// <summary>
        /// Process Create new city view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(CityViewModelCreate viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await cityService.Add(viewModel);

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
            var city = await cityService.Get(id);
            

            if (city != null)
            {
                CityViewModelEdit model = new CityViewModelEdit()
                {
                    Id = id,
                    Name = city.Name,
                    CountryId = city.CountryId,
                };
                model.Countries = (List<CountryViewModel>)await cityService.GetAllCountries();
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Process Edit view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> EditAsync(CityViewModelEdit viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await cityService.Update(viewModel);

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
            await cityService.Delete(id);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
