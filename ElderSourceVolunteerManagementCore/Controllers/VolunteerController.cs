using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class VolunteerController : Controller
    {
        private IVolunteerRepository repository;

        public VolunteerController(IVolunteerRepository repo)
        {
            repository = repo;
        }

        public ViewResult ListVolunteerEdit() => View(repository.Volunteer);

        // GET: /<controller>/
        public IActionResult VolunteerForm() => View(new Volunteer());

        public ViewResult Create() => View("EmployeeForm", new Volunteer());

        public ViewResult Edit(int VolunteerID) => View("EmployeeForm",repository.Volunteer.FirstOrDefault
            (vol => vol.VOLUNTEERID == VolunteerID));

        [HttpPost]
        public IActionResult EmployeeForm(Volunteer volunteer)
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
        }// end EmployeeForm method
    }// end VolunteerController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace
