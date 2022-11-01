using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;
using SBS.Tools;

namespace SBS.Controllers
{
    [Authorize]
    public class ContragentController : Controller
    {
        private readonly IContragentService service;

        public ContragentController(IContragentService service)
        {
            this.service = service;
        }

        // GET: ContragentController
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

        // GET: ContragentController/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ContragentViewModel();
            return View(model);
        }

        // POST: ContragentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContragentViewModel viewModel)
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
            var contragent = await service.Get(id);

            if (contragent != null)
            {
                return View(contragent);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: ContragentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
