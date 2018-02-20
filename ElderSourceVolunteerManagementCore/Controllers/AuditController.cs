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
        IVolunteerUpdateUserRespository volunteerUpdateUserRespository;

        public AuditController (IVolunteerUpdateUserRespository volunteerUpdateUserRespo)
        {
            volunteerUpdateUserRespository = volunteerUpdateUserRespo;
        }
        // GET: /<controller>/
        public IActionResult Index() => View(support());
        private AuditViewModel support()
        {
            AuditViewModel auditViewModel = new AuditViewModel();
            auditViewModel.AuditList = volunteerUpdateUserRespository.VolunteerUpdateUser;
            return auditViewModel;
        }
    }

    
}
