using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class VolunteerController : Controller
    {
        ApplicationDbContext context;
        private IVolunteerRepository repository;
        private IVolunteerUpdateUserRespository volunteerUpdateUserRespository;
        public string LoggedInUser => User.Identity.Name;

        public VolunteerController(IVolunteerRepository repo, IVolunteerUpdateUserRespository vRepo, ApplicationDbContext ctx)
        {
            repository = repo;
            volunteerUpdateUserRespository = vRepo;
            context = ctx;
        }// end VolunteerController constructor

        [Authorize(Roles = "Employee,Manager,Admin")]
        public ViewResult ListVolunteerEdit() => View(repository.Volunteer);

        // GET: /<controller>/
        public IActionResult VolunteerForm() => View(new Volunteer());

        public IActionResult CreateVolunteer(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                context.Database.BeginTransaction();
                repository.SaveVolunteer(volunteer);
                context.Database.CommitTransaction();
                return RedirectToAction("ThankYou", "Home");
            }// end if(ModelState.IsValid) check
            else
            {
                //something went wrong
                return View(volunteer);
            }// end else
        }// end CreateVolunteer method

        [Authorize(Roles = "Employee,Manager,Admin")]
        public ViewResult Create() => View("EmployeeForm", new Volunteer());
        
        [Authorize (Roles = "Employee,Manager,Admin")]
        public ViewResult Edit(int VolunteerID) => View("EmployeeForm",repository.Volunteer.FirstOrDefault
            (vol => vol.VOLUNTEERID == VolunteerID));

        [Authorize(Roles = "Employee,Manager,Admin")]
        [HttpPost]
        public IActionResult EmployeeForm(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                context.Database.BeginTransaction();
                repository.SaveVolunteer(volunteer);
                context.Database.CommitTransaction();
                context.Database.BeginTransaction();
                AddToVolUpdateUser(volunteer);
                context.Database.CommitTransaction();
                
                return RedirectToAction("ListVolunteerEdit", "Volunteer");
            }// end if(ModelState.IsValid) check
            else
            {
                //something went wrong
                return View(volunteer);
            }// end else
        }// end EmployeeForm method

        private void AddToVolUpdateUser (Volunteer volunteer)
        {
            Volunteer vol = repository.Volunteer.FirstOrDefault(vol1 => vol1.Email == volunteer.Email);
            VolunteerUpdateUser volunteerUpdateUser = new VolunteerUpdateUser
            {
                VOLUNTEERID = vol.VOLUNTEERID,
                Volunteer = vol,
                UserName = LoggedInUser,
                DateUpdated = System.DateTime.Now
            };
            volunteerUpdateUserRespository.SaveVolunteerUpdateUser(volunteerUpdateUser);
            //return volunteerUpdateUser;
        }// end AddToVolUpdateUser method
    }// end VolunteerController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace