using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Tools;

namespace SBS.Controllers
{
    /// <summary>
    /// Controller for Units
    /// </summary>
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class UnitController : Controller
    {
        private readonly IUnitService service;

        /// <summary>
        /// Init Controller
        /// </summary>
        /// <param name="service"></param>
        public UnitController(IUnitService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Sorted, Filtered and Paged Units List 
        /// </summary>
        /// <param name="sortExpression"></param>
        /// <param name="filterName"></param>
        /// <param name="filterDescription"></param>
        /// <param name="pg"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(
            string sortExpression = "",
            string filterName = "",
            string filterDescription = "",
            int pg = 1,
            int pageSize = 5)
        {
            SortHelper sortHelper = new SortHelper();
            sortHelper.SortExperssion = sortExpression;
            sortHelper.AddColumn("name");
            sortHelper.AddColumn("description");
            ViewData["sortModel"] = sortHelper;

            UnitFilterViewModel filter = new UnitFilterViewModel();
            filter.Name = filterName;
            filter.Description = filterDescription;
            ViewBag.UnitFilter = filter;

            List<UnitViewModel> units = await service.GetAll(filter, sortHelper, pg, pageSize);

            int totalRecors = service.GetCount(filter);
            PagerViewModel pager = new PagerViewModel(totalRecors, pg, pageSize);
            pager.SortExpression = sortExpression;
            ViewBag.Pager = pager;

            TempData["CurrentPage"] = pg;

            return View(units);
        }

        /// <summary>
        /// Prepare data for create view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            var model = new UnitViewModel();
            return View(model);
        }
        /// <summary>
        /// Process Create Unit voew data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(UnitViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            bool success = false;
            string errorMessage = string.Empty;
            if (service.IsExists(viewModel.Name))
            {
                errorMessage = "Unit name '" + viewModel.Name + "' exists already!";
            }
            else
            {
                try
                {
                    await service.Add(viewModel);
                    success = true;
                }
                catch (Exception ex)
                {
                    errorMessage += " " + ex.Message;
                }

            }

            int currentPage = 1;
            if (TempData["CurrentPage"] != null)
            {
                currentPage = (int)TempData["CurrentPage"];
            }

            if (success)
            {
                TempData["SuccessMessage"] = "Unit " + viewModel.Name + " created successfully!";
                return RedirectToAction(nameof(Index), new { pg = currentPage });
            }
            else
            {
                TempData["ErrorMessage"] = errorMessage;
                ModelState.AddModelError("", errorMessage);
                return View(viewModel);
            }

        }

        /// <summary>
        /// Prepare details view data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var unit = await service.Get(id);

            if (unit != null)
            {
                return View(unit);
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Prepare edit view data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var unit = await service.Get(id);
            TempData.Keep();
            if (unit != null)
            {
                return View(unit);
            }

            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Process edit data from view
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> EditAsync(UnitViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            bool success = false;
            string errorMessage = string.Empty;
            if (service.IsExists(viewModel.Name, viewModel.Id))
            {
                errorMessage = "Unit name '" + viewModel.Name + "' exists already!";
            }
            else
            {
                try
                {
                    await service.Update(viewModel);
                    success = true;
                }
                catch (Exception ex)
                {
                    errorMessage += " " + ex.Message;
                }

            }

            int currentPage = 1;
            if (TempData["CurrentPage"] != null)
            {
                currentPage = (int)TempData["CurrentPage"];
            }

            if (success)
            {
                TempData["SuccessMessage"] = "Unit " + viewModel.Name + " saved successfully!";
                return RedirectToAction(nameof(Index), new { pg = currentPage });
            }
            else
            {
                TempData["ErrorMessage"] = errorMessage;
                ModelState.AddModelError("", errorMessage);
                return View(viewModel);
            }
        }

        /// <summary>
        /// Prepare delete view data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var unit = await service.Get(id);
            TempData.Keep();
            if (unit != null)
            {
                return View(unit);
            }

            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Process delete data from view
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Delete(UnitViewModel viewModel)
        {

            await service.Delete(viewModel.Id);

            try
            {
                TempData["SuccessMessage"] = "Unit " + viewModel.Name + " deleted successfully!";

                int currentPage = 1;
                if (TempData["CurrentPage"] != null)
                {
                    currentPage = (int)TempData?["CurrentPage"];
                }

                return RedirectToAction(nameof(Index), new { pg = currentPage });
            }
            catch
            {
                return View();
            }
        }

    }
}
