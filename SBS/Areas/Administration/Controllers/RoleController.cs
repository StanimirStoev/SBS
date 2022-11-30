using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBS.Areas.Administration.Models;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Core.Services;

namespace SBS.Areas.Administration.Controllers
{
    public class RoleController : AdminController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

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

        [HttpGet]
        public ActionResult Create()
        {
            var model = new RoleViewModel();
            return View(model);
        }
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
