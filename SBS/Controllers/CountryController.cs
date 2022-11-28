using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;
using SBS.Core.Models;

namespace SBS.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        // GET: CountryController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var countries = await countryService.GetAll();
            ViewData["Title"] = "Countries";

            return View(countries);
        }

        // GET: CountryController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CountryViewModel();
            return View(model);
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CountryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await countryService.Add(viewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var country = await countryService.Get(id);

            if (country != null)
            {
                return View(country);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(CountryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await countryService.Update(viewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await countryService.Delete(id);

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
