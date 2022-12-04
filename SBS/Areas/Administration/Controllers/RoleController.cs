using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBS.Areas.Administration.Models;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;

namespace SBS.Areas.Administration.Controllers
{
    /// <summary>
    /// Controller for roles
    /// </summary>
    public class RoleController : AdminController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        /// <summary>
        /// Init controller
        /// </summary>
        /// <param name="roleManager"></param>
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        /// <summary>
        /// Prepare data for roles view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var roles = await roleManager.Roles
                .OrderBy(r => r.Name)
                .Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                }).ToListAsync();
            ViewData["Title"] = "Roles";

            return View(roles);
        }

        /// <summary>
        /// Prepare data for create new role view 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            var model = new RoleViewModel();
            return View(model);
        }
        /// <summary>
        /// Process Create new role view data
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            await roleManager.CreateAsync(new IdentityRole { Name = viewModel.Name });

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
            var role = await roleManager.FindByIdAsync(id.ToString());


            if (role != null)
            {
                RoleViewModel model = new RoleViewModel()
                {
                    Id = role.Id,
                    Name = role.Name,
                };

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
        public async Task<ActionResult> EditAsync(RoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            var role = await roleManager.FindByIdAsync(viewModel.Id);
            role.Name = viewModel.Name;
            await roleManager.UpdateAsync(role);

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
