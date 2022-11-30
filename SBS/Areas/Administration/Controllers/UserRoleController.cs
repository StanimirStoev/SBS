using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBS.Areas.Administration.Models;
using SBS.Infrastructure.Data.Models.Account;
using System.Reflection;

namespace SBS.Areas.Administration.Controllers
{
    public class UserRoleController : AdminController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<RoleViewModel> roles = await GetAllRoleViewModels();

            List<UserRoleViewModel> users = await userManager.Users
                .OrderBy(u => u.UserName)
                .Select(u => new UserRoleViewModel()
                {
                    Id = u.Id,
                    Name = u.UserName,
                }).ToListAsync();
            foreach(UserRoleViewModel user in users)
            {
                user.Roles = await GetAllRoleViewModels();
                foreach (RoleViewModel role in user.Roles)
                {
                    if (user.Id != null)
                    {
                        ApplicationUser appUser = await userManager.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                        if (appUser != null)
                        {
                            role.Selected = await userManager.IsInRoleAsync(appUser, role.Name);
                        }
                    }
                }
            }

            ViewBag.Roles = roles;
            ViewData["Title"] = "Users To Roles";

            return View(users);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            ApplicationUser appUser = await userManager.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());

            if (appUser != null)
            {
                UserRoleViewModel model = new UserRoleViewModel()
                {
                    Id = appUser.Id,
                    Name = appUser.UserName,
                };
                model.Roles = await GetAllRoleViewModels();
                foreach (RoleViewModel role in model.Roles)
                {
                    if (model.Id != null)
                    {
                        ApplicationUser user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == model.Id);
                        if (user != null)
                        {
                            role.Selected = await userManager.IsInRoleAsync(user, role.Name);
                        }
                    }
                }

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> EditAsync(UserRoleViewModel viewModel)
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

        private async Task<List<RoleViewModel>> GetAllRoleViewModels()
        {
            return await roleManager.Roles
                .OrderBy(r => r.Name)
                .Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                }).ToListAsync();
        }
    }
}
