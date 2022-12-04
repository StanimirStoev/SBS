using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SBS.Areas.Administration.Models;
using SBS.Infrastructure.Data.Models.Account;
using System.Reflection;

namespace SBS.Areas.Administration.Controllers
{
    /// <summary>
    /// Controller for Users with roles
    /// </summary>
    public class UserRoleController : AdminController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        /// <summary>
        /// Init controller
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        public UserRoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        /// <summary>
        /// Prepare data for Users with roles view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<SelectListItem> roles = await GetAllRoleViewModels();

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
                foreach (SelectListItem role in user.Roles)
                {
                    if (user.Id != null)
                    {
                        ApplicationUser appUser = await userManager.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                        if (appUser != null)
                        {
                            role.Selected = await userManager.IsInRoleAsync(appUser, role.Text);
                        }
                    }
                }
            }

            ViewBag.Roles = roles;
            ViewData["Title"] = "Users To Roles";

            return View(users);
        }

        /// <summary>
        /// Prepare data for edit view 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                foreach (SelectListItem role in model.Roles)
                {
                    if (model.Id != null)
                    {
                        ApplicationUser user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == model.Id);
                        if (user != null)
                        {
                            role.Selected = await userManager.IsInRoleAsync(user, role.Text);
                        }
                    }
                }

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
        public async Task<ActionResult> EditAsync(UserRoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // if state is not valid - return to continue edit data
                return View(viewModel);
            }

            foreach(var role in viewModel.Roles)
            {
                ApplicationUser user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == viewModel.Id);
                if (user != null)
                {
                    bool isInRole = await userManager.IsInRoleAsync(user, role.Text);
                    if (isInRole != role.Selected)
                    {
                        if(role.Selected)
                        {
                            await userManager.AddToRoleAsync(user, role.Text);
                        }
                        else
                        {
                            await userManager.RemoveFromRoleAsync(user, role.Text);
                        }

                    }
                }
            }

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
        /// Get roles
        /// </summary>
        /// <returns></returns>
        private async Task<List<SelectListItem>> GetAllRoleViewModels()
        {
            return await roleManager.Roles
                .OrderBy(r => r.Name)
                .Select(r => new SelectListItem
                {
                    Value = r.Id,
                    Text = r.Name,
                }).ToListAsync();
        }
    }
}
