using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using ElderSourceVolunteerManagementCore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    [Authorize(Roles = "Manager,Admin")]
    public class AuditController : Controller
    {
        ApplicationDbContext context;
        IVolunteerUpdateUserRespository volunteerUpdateUserRespository;
        IVolunteerRepository volunteerRepository;

        public AuditController (IVolunteerUpdateUserRespository volunteerUpdateUserRespo,
            ApplicationDbContext ctx, IVolunteerRepository volRepo)
        {
            context = ctx;
            volunteerUpdateUserRespository = volunteerUpdateUserRespo;
            volunteerRepository = volRepo;
        }// end AuditController constructor
        // GET: /<controller>/
        public IActionResult Index() => View(Support());
        private AuditViewModel Support()
        {
            AuditViewModel auditViewModel = new AuditViewModel();
            auditViewModel.AuditList = context.VolunteerUpdateUser.Include("Volunteer")
                .ToList();
            return auditViewModel;
        }// end AuditViewModel
    }// end AuditController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace
