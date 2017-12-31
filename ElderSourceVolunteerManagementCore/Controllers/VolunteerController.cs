using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult VolunteerForm() => View();

        public ViewResult EmployeeForm(int VolunteerID) => View(repository.Volunteer.FirstOrDefault
            (vol => vol.VOLUNTEERID == VolunteerID));
    }
}
