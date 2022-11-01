using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;
using SBS.Core.Models;

namespace SBS.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService service;

        public StoreController(IStoreService service)
        {
            this.service = service;
        }

        // GET: ContragentController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var stores = await service.GetAll();
            ViewData["Title"] = "Stores";

            return View(stores);
        }

        // GET: ContragentController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new StoreViewModel();
            return View(model);
        }

        // POST: ContragentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: ContragentController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var store = await service.Get(id);

            if (store != null)
            {
                return View(store);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: ContragentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // POST: ContragentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
    }
}
