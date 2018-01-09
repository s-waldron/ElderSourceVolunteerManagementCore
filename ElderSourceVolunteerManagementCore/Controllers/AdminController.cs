using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using ElderSourceVolunteerManagementCore.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<AppUsers> userManager;
        private IUserValidator<AppUsers> userValidator;
        private IPasswordValidator<AppUsers> passwordValidator;
        private IPasswordHasher<AppUsers> passwordHasher;

        public AdminController(UserManager<AppUsers> usrMgr,
            IUserValidator<AppUsers> userValid,
            IPasswordValidator<AppUsers> passValid,
            IPasswordHasher<AppUsers> passwordHash)
        {
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
        }// end AdminController constructor
        // GET: /<controller>/
        public ViewResult Index() => View(userManager.Users);

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUsers user = new AppUsers
                {
                    UserName = model.Name,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }// end if (result.Succeeded) check
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }// end foreach loop
                }// end else
            }// end if (ModelState.IsValid) check
            return View(model);
        }// end Create HttpPost method

        public async Task<IActionResult> Edit(string id)
        {
            AppUsers user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                return View(user);
            }// end if(user != null) check
            else
            {
                return RedirectToAction("Index");
            }// end else
        }// end Edit method

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string password,
            string firstName, string lastName)
        {
            AppUsers user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                user.Email = email;
                user.FirstName = firstName;
                user.LastName = lastName;
                IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }// end if(!validEmail.Succeeded) check
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    }// end if(validPass.Succeeded) check
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }// end else
                }// end if(!string.IsNullOrEmpty(password)) check
                if((validEmail.Succeeded && validPass == null) || 
                    (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }// end if(result.Succeeded) check
                    else
                    {
                        AddErrorsFromResult(result);
                    }// end else
                }// end if((validEmail.Succeeded && validPass == null)...) check
            }// end if(user != null) check
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }// end else
            return View(user);
        }// end Edit HttpPost method

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }// end foreach loop
        }// end AddErrorsFromResult method
    }// end AdminController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace
