using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElderSourceVolunteerManagementCore.Models;
using ElderSourceVolunteerManagementCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class Volunteer2OpportunityHoursUpdateController : Controller
    {
        ApplicationDbContext context;
        IVolunteer2OpportunityRepository v2oRepo;
        IVolunteer2OpportunityHoursWorkedRepository v2oHWRepo;

        public Volunteer2OpportunityHoursUpdateController (ApplicationDbContext ctx,
            IVolunteer2OpportunityRepository volunteer2OpportunityRepository, 
            IVolunteer2OpportunityHoursWorkedRepository volunteer2OpportunityHoursWorkedRepository)
        {
            context = ctx;
            v2oRepo = volunteer2OpportunityRepository;
            v2oHWRepo = volunteer2OpportunityHoursWorkedRepository;
        }

        public ViewResult Index(int VOLUNTEER2OPPORTUNITYID)
        {
            
            if (ModelState.IsValid)
            {
                return View(new Volunteer2OpportunityUpdateHoursViewModel
                {
                    Volunteer2Opportunity = v2oRepo.Volunteer2Opportunity.FirstOrDefault(v2o => v2o.VOLUNTEER2OPPORTUNITYID == 115)
                });
            }
            else
            {
                return View("Home/Index");
            }
        }
        
        [HttpPost]
        public RedirectToActionResult UpdateHours(int VOLUNTEER2OPPORTUNITYID, int Hours, DateTime DateWorked)
        {
            Volunteer2Opportunity volunteer2Opportunity = v2oRepo.Volunteer2Opportunity.FirstOrDefault(v2o => v2o.VOLUNTEER2OPPORTUNITYID == 115);
            context.Database.BeginTransaction();
            Volunteer2OpportunityHoursWorked volunteer2OpportunityHoursWorked = new Volunteer2OpportunityHoursWorked
            {
                VOLUNTEER2OPPORTUNITYID = 115,
                Volunteer2Opportunity = volunteer2Opportunity,
                HoursWorked = Hours,
                DateWorked = DateWorked
            };
            v2oHWRepo.SaveVolunteer2OpportunityHoursWorked(volunteer2OpportunityHoursWorked);
            context.Database.CommitTransaction();
            return RedirectToAction("ListVolunteerEdit", "Volunteer");
        }
    }
}
