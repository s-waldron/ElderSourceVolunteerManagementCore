using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using ElderSourceVolunteerManagementCore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUsers> userManager;
        private SignInManager<AppUsers> signInManager;

        public AccountController(UserManager<AppUsers> userMgr, SignInManager<AppUsers> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }// end AccountController constructor

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }// end Login method

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUsers user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager
                        .PasswordSignInAsync(user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }// end if (result.Succeeded) check
                }// end if (user != null) check
                ModelState.AddModelError(nameof(LoginModel.Email), "Invalid user or password");
            }// end if(ModelState.IsValid) check
            return View(details);
        }// end Login HttpPost method

        public async Task<IActionResult> Logout(LoginModel details, string returnUrl)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }// end Logout method
    }// end AccountController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace
