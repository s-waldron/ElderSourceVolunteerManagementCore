using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class VolunteerController : Controller
    {
        private IVolunteerRepository repository;
        private IVolunteerUpdateUserRespository volunteerUpdateUserRespository;
        public string LoggedInUser => User.Identity.Name;

        public VolunteerController(IVolunteerRepository repo, IVolunteerUpdateUserRespository vRepo)
        {
            repository = repo;
            volunteerUpdateUserRespository = vRepo;
        }// end VolunteerController constructor

        [Authorize(Roles = "Employee,Manager,Admin")]
        public ViewResult ListVolunteerEdit() => View(repository.Volunteer);

        // GET: /<controller>/
        public IActionResult VolunteerForm() => View(new Volunteer());

        public IActionResult CreateVolunteer(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                repository.SaveVolunteer(volunteer);
                return RedirectToAction("ListVolunteerEdit", "Volunteer");
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
                repository.SaveVolunteer(volunteer);
                VolunteerUpdateUser volunteerUpdateUser = new VolunteerUpdateUser();
                volunteerUpdateUser.VOLUNTEERID = repository.Volunteer.FirstOrDefault(vol => vol.Email == volunteer.Email).VOLUNTEERID;
                volunteerUpdateUser.Volunteer = repository.Volunteer.FirstOrDefault(vol1 => vol1.Email == volunteer.Email);
                volunteerUpdateUser.UserName = LoggedInUser;
                volunteerUpdateUser.DateUpdated = System.DateTime.Now;
                volunteerUpdateUserRespository.SaveVolunteerUpdateUser(volunteerUpdateUser);
                return RedirectToAction("ListVolunteerEdit", "Volunteer");
            }// end if(ModelState.IsValid) check
            else
            {
                //something went wrong
                return View(volunteer);
            }// end else
        }// end EmployeeForm method
    }// end VolunteerController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace