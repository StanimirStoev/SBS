using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;
using SBS.Core.Models;

namespace SBS.Controllers
{
    [Authorize]
    public class CityController : Controller
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        // GET: CityController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var cities = await cityService.GetAll();
            ViewData["Title"] = "Cities";

            return View(cities);
        }

        // GET: CityController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var model = new CityViewModelCreate();
            model.Countries = (List<CountryViewModel>)await cityService.GetAllCountries();
            return View(model);
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: CityController/Edit/5
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

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
