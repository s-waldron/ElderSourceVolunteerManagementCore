using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using ElderSourceVolunteerManagementCore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class AuditController : Controller
    {
        ApplicationDbContext context;
        IVolunteerUpdateUserRespository volunteerUpdateUserRespository;

        public AuditController (IVolunteerUpdateUserRespository volunteerUpdateUserRespo, ApplicationDbContext ctx)
        {
            context = ctx;
            volunteerUpdateUserRespository = volunteerUpdateUserRespo;
        }// end AuditController constructor
        // GET: /<controller>/
        public IActionResult Index() => View(Support());
        private AuditViewModel Support()
        {
            AuditViewModel auditViewModel = new AuditViewModel();
            auditViewModel.AuditList = volunteerUpdateUserRespository.VolunteerUpdateUser;
            return auditViewModel;
        }// end AuditViewModel
    }// end AuditController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace
