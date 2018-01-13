using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ElderSourceVolunteerManagementCore.Models;
using ElderSourceVolunteerManagementCore.Models.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    [Authorize(Roles = "Admin")]
    
    public class RoleManagementController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<AppUsers> userManager;

        public RoleManagementController(RoleManager<IdentityRole> roleMgr, UserManager<AppUsers> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
        }// end RoleAdminController constructor
        // GET: /<controller>/
        public ViewResult RoleEdit() => View(roleManager.Roles);

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleEdit");
                }// end if (result.Succeeded) check
                else
                {
                    AddErrorsFromResult(result);
                }// end else
            }// end if (ModelState.IsValid) check
            return View(name);
        }// end Create HttpPost method

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleEdit");
                }// end if (result.Succeeded) check
                else
                {
                    AddErrorsFromResult(result);
                }// end else
            }// end if (role != null) check
            else
            {
                ModelState.AddModelError("", "No role found");
            }// end else
            return View("RoleEdit", roleManager.Roles);
        }// end Delete HttpPost method

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }// end foreach loop
        }// end AddErrorFromResult method

        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<AppUsers> members = new List<AppUsers>();
            List<AppUsers> nonMembers = new List<AppUsers>();
            foreach (AppUsers user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }// end foreach loop
            return View(new RoleEditModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }// end Edit method

        [HttpPost]
        public async Task<IActionResult> Edit(RoleModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    AppUsers user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }// end if (!result.Succeeded) check
                    }// end if (user != null) check
                }// end foreach loop
                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    AppUsers user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }// end if (!result.Succeeded) check
                    }// end if (user != null) check
                }// end foreach loop
            }// end if (ModleState.IsValid) check
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(RoleEdit));
            }// end if (ModelState.IsValid) check
            else
            {
                return await Edit(model.RoleId);
            }// end else
        }// end Edit HttpPost method
    }// end RoleAdminController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace
