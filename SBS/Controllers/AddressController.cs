using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;
using SBS.Core.Models;

namespace SBS.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        // GET: AddressController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var addresses = await addressService.GetAll();
            ViewData["Title"] = "Addresses";

            return View(addresses);
        }

        // GET: AddressController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new AddressViewModel();
            return View(model);
        }

        // POST: AddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddressViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await addressService.Add(viewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddressController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var city = await addressService.Get(id);

            if (city != null)
            {
                return View(city);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: AddressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(AddressViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await addressService.Update(viewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: AddressController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            await addressService.Delete(id);

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
